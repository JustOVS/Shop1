using Shop.Data.Dto;
using System.Collections.Generic;

namespace Shop.Data
{
    public interface IShopRepository
    {
        DataWrapper<OrderDto> GetOrderById(long id);
        DataWrapper<List<OrderDto>> GetOrderByCustomerId(long customerId);
        DataWrapper<OrderDto> CreateOrder(OrderDto order);
    }
}