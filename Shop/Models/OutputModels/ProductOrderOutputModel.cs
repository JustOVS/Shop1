namespace Shop.API.Models.OutputModels
{
    public class ProductOrderOutputModel
    {
        public long? Id { get; set; }
        public long? OrderId { get; set; }
        public int Quantity { get; set; }
        public ProductOutputModel Product { get; set; }
    }
}