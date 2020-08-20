namespace Shop.API.Models.OutputModels
{
    public class ProductOutputModel : BaseProductOutputModel
    {

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