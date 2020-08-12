
using Microsoft.Extensions.Options;
using Shop.Core;
using Shop.Data.Dto;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;

namespace Shop.Data
{
    public class ShopRepository : IShopRepository
    {
        private readonly IDbConnection _connection;

        public ShopRepository(IOptions<StorageOptions> options)
        {
            _connection = new SqlConnection(options.Value.DBConnectionString);
        }

        public LeadRepository()
        { }
        public DataWrapper<OrderDto> GetOrderById(long id)
        {
            var result = new DataWrapper<OrderDto>();
            try
            {
                result.Data = await _storage.OrderGetById(id);
                result.RequestData.OrderItems = await _storage.OrderProductsGetByOrderId((int)result.RequestData.Id);
                result.IsOkay = true;
            }
            catch (Exception ex)
            {
                result.ExMessage = ex.Message;
            }
            return result;
        }

        public async ValueTask<RequestResult<List<Order>>> OrderGetByCustomerId(int id)
        {
            var result = new RequestResult<List<Order>>();
            try
            {
                result.RequestData = await _storage.OrderGetByCustomerId(id);
                foreach (var order in result.RequestData)
                {
                    order.OrderItems = await _storage.OrderProductsGetByOrderId((int)order.Id);
                }
                result.IsOkay = true;
            }
            catch (Exception ex)
            {
                result.ExMessage = ex.Message;
            }
            return result;
        }

        public async ValueTask<RequestResult<Order>> CreateOrder(Order order)
        {
            var result = new RequestResult<Order>();

            try
            {
                _storage.TransactionStart();
                result.RequestData = (await _storage.OrderInsert(order));
                result.RequestData.OrderItems = new List<Order_Product>();

                foreach (var item in order.OrderItems)
                {
                    item.OrderId = result.RequestData.Id;
                    var productPrice = (await _storage.ProductsGetById(item.Product.Id)).Price;
                    item.LocalPrice = productPrice * item.Value * order.Valute.Nominal / order.Valute.Value;
                    result.RequestData.OrderItems.Add(await _storage.OrderProductInsert(item));
                }
                _storage.TransactionCommit();
                result.IsOkay = true;
            }
            catch (Exception ex)
            {
                _storage.TransactioRollBack();
                result.ExMessage = ex.Message;
            }
            return result;
        }
    }
}
