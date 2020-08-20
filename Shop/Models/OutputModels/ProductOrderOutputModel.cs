namespace Shop.API.Models.OutputModels
{
    public class ProductOrderOutputModel
    {

        public int Quantity { get; set; }
        public ProductForOrderOutputModel Product { get; set; }
    }
}