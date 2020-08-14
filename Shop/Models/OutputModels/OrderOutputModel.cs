using System;
using System.Collections.Generic;


namespace Shop.API.Models.OutputModels
{
    public class OrderOutputModel
    {
        public long Id { get; set; }
        public string Time { get; set; }
        public string Address { get; set; }
        public int CustomerId { get; set; }
        public List<ProductOrderOutputModel> OrderItems { get; set; }
        public bool IsDeleted { get; set; }
    }
}
