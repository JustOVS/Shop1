using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Shop.API.Models.InputModels
{
    public class OrderInputModel
    {
        public long? Id { get; set; }
        public string? Address { get; set; }
        public int CustomerId { get; set; }
        public List<ProductOrderInputModel> OrderItems { get; set; }


    }
}
