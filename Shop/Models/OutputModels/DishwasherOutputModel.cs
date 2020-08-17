

namespace Shop.API.Models.OutputModels
{
    public class DishwasherOutputModel : BaseProductOutputModel
    {
        public bool DryingMode { get; set; }
        public int NoiseLevel { get; set; }
        public int NumberOfCompartments { get; set; }
    }
}
