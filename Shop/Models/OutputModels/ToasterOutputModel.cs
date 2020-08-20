

namespace Shop.API.Models.OutputModels
{
    public class ToasterOutputModel : BaseProductOutputModel
    {
        public int NumberOfRecipes { get; set; }
        public int NumberOfCompartments { get; set; }
        public int NumberOfModes { get; set; }
    }
}
