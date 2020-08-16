using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Shop.API.Models.InputModels
{
    public class ProductInputModel
    {
		public int? Id { get; set; }
		public decimal Price { get; set; }
		public string Manufacturer { get; set; }
		public string Model { get; set; }
		public int? YearOfManufacture { get; set; }
		public int? Length { get; set; }
		public int? Width { get; set; }
		public int? Height { get; set; }
		public int? AirSpeed { get; set; }
		public bool? DryingMode { get; set; }
		public int? NumberOfRecipes { get; set; }
		public int? NumberOfNozzles { get; set; }
		public int? Power { get; set; }
		public int? Volume { get; set; }
		public bool? DescalingProtection { get; set; }
		public int? NoiseLevel { get; set; }
		public int? NumberOfCompartments { get; set; }
		public int? NumberOfModes { get; set; }
		public bool? IsDeleted { get; set; }
	}
}
