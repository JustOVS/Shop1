

namespace Shop.API.Models.OutputModels
{
    public class KitchenStoveOutputModel : BaseProductOutputModel
    {
        public int NumberOfRecipes { get; set; }
        public bool DescalingProtection { get; set; }
        public int NumberOfCompartments { get; set; }
    }
}
