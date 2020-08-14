using System;
using System.Collections.Generic;


namespace Shop.Data.Dto
{
    public class OrderDto
    {
            public long? Id { get; set; }
            public DateTime? Time { get; set; }
            public string? Address { get; set; }
            public int CustomerId { get; set; }
            public List<ProductOrderWithFullProductInfoDto> OrderItems { get; set; }
            public bool? IsDeleted { get; set; }

    }
}
