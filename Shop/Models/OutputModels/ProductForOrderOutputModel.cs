using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Shop.API.Models.OutputModels
{
    public class ProductForOrderOutputModel
    {
        public int? Id { get; set; }
        public decimal Price { get; set; }
        public string Manufacturer { get; set; }
        public string Model { get; set; }
        public int? YearOfManufacture { get; set; }
    }
}
