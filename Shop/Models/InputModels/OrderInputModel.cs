using System.Collections.Generic;


namespace Shop.API.Models.InputModels
{
    public class OrderInputModel
    {
        public long? Id { get; set; }
        public string Address { get; set; }
        public int CustomerId { get; set; }
        public List<ProductOrderInputModel> OrderItems { get; set; }


    }
}
