
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
                result.Data = _connection.Query<OrderDto, ProductOrderDto, ProductDto, OrderDto>(
                    "GetOrderWithProductsByOrderId",
                    (order, productOrder, product) =>
                    {
                        OrderDto orderEntry;
                        if (!orderDictionary.TryGetValue(order.Id.Value, out orderEntry))
                        {
                            orderEntry = order;
                            orderEntry.OrderItems = new List<ProductOrderDto>();
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

        public DataWrapper<List<OrderDto>> GetOrderByCustomerId(int customerId)
        {
            var orderDictionary = new Dictionary<long, OrderDto>();
            var result = new DataWrapper<List<OrderDto>>();
            try
            {
                result.Data = _connection.Query<OrderDto, ProductOrderDto, ProductDto, OrderDto>(
                    "Order_GetByCustomerId",
                    (order, productOrder, product) =>
                    {
                        OrderDto orderEntry;
                        if (!orderDictionary.TryGetValue(order.Id.Value, out orderEntry))
                        {
                            orderEntry = order;
                            orderEntry.OrderItems = new List<ProductOrderDto>();
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
            using (_connection)
            {
                _connection.Open();
                using (var transaction = _connection.BeginTransaction())
                {
                    try
                    {
                        result.Data = _connection.Query<OrderDto>("Order_Add_Or_Update @id, @address, @customerId", 
                        new
                        {
                            order.Id,
                            order.Address,
                            order.CustomerId

                        }, transaction: transaction).FirstOrDefault();

                        result.Data.OrderItems = new List<ProductOrderDto>();
                        foreach (var item in order.OrderItems)
                        {

                            result.Data.OrderItems.Add(_connection.Query<ProductOrderDto, ProductDto, ProductOrderDto>("Product_Order_Add_Or_Update",
                                (productOrder, product) =>
                                {
                                    ProductOrderDto productOrderEntry;
                                    productOrderEntry = productOrder;
                                    productOrderEntry.Product = product;
                                    return productOrderEntry;
                                },

                                new
                                {
                                    ProductId =item.Product.Id,
                                    OrderId = result.Data.Id,
                                    quantity = item.Quantity
                                },
                                splitOn: "Id", transaction: transaction, commandType: CommandType.StoredProcedure).FirstOrDefault());
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

        public DataWrapper<int> DeleteOrderById(long id)
        {
            var result = new DataWrapper<int>();

            try 
            { 
            result.Data = _connection.Execute("Order_Delete", new { id }, commandType: CommandType.StoredProcedure);
            result.IsOk = true;
            }

            catch (Exception e)
            {
                result.ExceptionMessage = e.Message;
            }
            return result;
        }

        public DataWrapper<List<ProductDto>> GetAllProducts()
        {
            
            var result = new DataWrapper<List<ProductDto>>();
            try
            {
                result.Data = _connection.Query<ProductDto>("Product_GetAll", commandType: CommandType.StoredProcedure).ToList();
                result.IsOk = true;
            }
            catch (Exception e)
            {
                result.ExceptionMessage = e.Message;
            }
            return result;
        }

        public DataWrapper<ProductDto> GetProductById(long id)
        {

            var result = new DataWrapper<ProductDto>();
            try
            {
                result.Data = _connection.Query<ProductDto>("Product_GetById", new { id }, commandType: CommandType.StoredProcedure).FirstOrDefault();
                result.IsOk = true;
            }
            catch (Exception e)
            {
                result.ExceptionMessage = e.Message;
            }
            return result;
        }
        public DataWrapper<long> AddProduct(ProductDto product)
        {

            var result = new DataWrapper<long>();
            try
            {
                result.Data = _connection.Query<long>("Product_Add_Or_Update", product, commandType: CommandType.StoredProcedure).FirstOrDefault();
                result.IsOk = true;
            }
            catch (Exception e)
            {
                result.ExceptionMessage = e.Message;
            }
            return result;
        }

        public DataWrapper<int> DeleteProductById(long id)
        {
            var result = new DataWrapper<int>();

            try
            {
                result.Data = _connection.Execute("Product_Delete", new { id }, commandType: CommandType.StoredProcedure);
                result.IsOk = true;
            }

            catch (Exception e)
            {
                result.ExceptionMessage = e.Message;
            }
            return result;
        }

        public DataWrapper<int> UpdateProduct(ProductDto product)
        {

            var result = new DataWrapper<int>();
            try
            {
                result.Data = _connection.Execute("Product_Add_Or_Update", product, commandType: CommandType.StoredProcedure);
                result.IsOk = true;
            }
            catch (Exception e)
            {
                result.ExceptionMessage = e.Message;
            }
            return result;
        }
    }
}
