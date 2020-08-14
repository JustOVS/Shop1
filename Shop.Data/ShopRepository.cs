﻿
using Microsoft.Extensions.Options;
using Shop.Core;
using Shop.Data.Dto;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using Dapper;

namespace Shop.Data
{
    public class ShopRepository : IShopRepository
    {
        private readonly IDbConnection _connection;

        public ShopRepository(IOptions<StorageOptions> options)
        {
            _connection = new SqlConnection(options.Value.DBConnectionString);
        }

        public ShopRepository()
        { }
        public DataWrapper<OrderDto> GetOrderById(long id)
        {
            var orderDictionary = new Dictionary<long, OrderDto>();
            var result = new DataWrapper<OrderDto>();
            try
            {
                result.Data = _connection.Query<OrderDto, ProductOrderWithFullProductInfoDto, ProductDto, OrderDto>(
                    "Order_GetById",
                    (order, productOrder, product) =>
                    {
                        OrderDto orderEntry;
                        if (!orderDictionary.TryGetValue(order.Id.Value, out orderEntry))
                        {
                            orderEntry = order;
                            orderEntry.OrderItems = new List<ProductOrderWithFullProductInfoDto>();
                            orderDictionary.Add(orderEntry.Id.Value, orderEntry);
                        }
                        productOrder.Product = product;
                        orderEntry.OrderItems.Add(productOrder);

                        return orderEntry;

                    },
                    new { id }, splitOn: "Id",
                    commandType: CommandType.StoredProcedure).FirstOrDefault();
                result.IsOk = true;
            }
            catch (Exception e)
            {
                result.ExceptionMessage = e.Message;
            }
            return result;
        }

        public DataWrapper<List<OrderDto>> GetOrderByCustomerId(long customerId)
        {
            var orderDictionary = new Dictionary<long, OrderDto>();
            var result = new DataWrapper<List<OrderDto>>();
            try
            {
                result.Data = _connection.Query<OrderDto, ProductOrderWithFullProductInfoDto, ProductDto, OrderDto>(
                    "Order_GetByCustomerId",
                    (order, productOrder, product) =>
                    {
                        OrderDto orderEntry;
                        if (!orderDictionary.TryGetValue(order.Id.Value, out orderEntry))
                        {
                            orderEntry = order;
                            orderEntry.OrderItems = new List<ProductOrderWithFullProductInfoDto>();
                            orderDictionary.Add(orderEntry.Id.Value, orderEntry);
                        }
                        productOrder.Product = product;
                        orderEntry.OrderItems.Add(productOrder);

                        return orderEntry;

                    },
                    new { customerId }, splitOn: "Id",
                    commandType: CommandType.StoredProcedure).ToList();
                result.IsOk = true;
            }
            catch (Exception e)
            {
                result.ExceptionMessage = e.Message;
            }
            return result;
        }

        public DataWrapper<OrderDto> CreateOrder(OrderDto order)
        {
            var result = new DataWrapper<OrderDto>();
            IDbTransaction transaction = _connection.BeginTransaction();
            try
            {
                result.Data = _connection.Query<OrderDto>("Order_Add_Or_Update", order, commandType: CommandType.StoredProcedure).FirstOrDefault();

                result.Data.OrderItems = new List<ProductOrderWithFullProductInfoDto>();
                foreach (var item in order.OrderItems)
                {
                    item.OrderId = result.Data.Id;
                    result.Data.OrderItems.Add(_connection.Query<ProductOrderWithFullProductInfoDto>("Product_Order_Add_Or_Update", item, commandType: CommandType.StoredProcedure).FirstOrDefault());
                }
                transaction.Commit();
                result.IsOk = true;
            }
            catch (Exception ex)
            {
                transaction.Rollback();
                result.ExceptionMessage = ex.Message;
            }
            return result;
        }
    }
}
