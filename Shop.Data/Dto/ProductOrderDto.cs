using System;
using System.Collections.Generic;
using System.Text;

namespace Shop.Data.Dto
{
    public class ProductOrderDto
    {
        public long? Id { get; set; }
        public long? OrderId { get; set; }
        public ProductDto Product { get; set; }
        public int Quantity { get; set; }
    }
}
