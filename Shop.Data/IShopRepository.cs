using Shop.Data.Dto;
using System.Collections.Generic;

namespace Shop.Data
{
    public interface IShopRepository
    {
        DataWrapper<OrderDto> GetOrderById(long id);
        DataWrapper<List<OrderDto>> GetOrderByCustomerId(int customerId);
        DataWrapper<OrderDto> CreateOrder(OrderDto order);
        DataWrapper<int> DeleteOrderById(long id);
        DataWrapper<long> AddProduct(ProductDto product);
        DataWrapper<int> DeleteProductById(long id);
        DataWrapper<List<ProductDto>> GetAllProducts();
        DataWrapper<ProductDto> GetProductById(long id);
        DataWrapper<int> UpdateProduct(ProductDto product);
    }
}