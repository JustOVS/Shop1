using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Shop.API.Models.OutputModels
{
    public class BaseProductOutputModel : ProductForOrderOutputModel
    {
		
		public int? Length { get; set; }
		public int? Width { get; set; }
		public int? Height { get; set; }
		public string CategoryName { get; set; }
	}
}
