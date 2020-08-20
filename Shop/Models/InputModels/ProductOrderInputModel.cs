namespace Shop.API.Models.InputModels
{
    public class ProductOrderInputModel
    {
        public long? Id { get; set; }
        public long? OrderId { get; set; }
        public int Quantity { get; set; }
        public long ProductId { get; set; }
    }
}