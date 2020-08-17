
namespace Shop.API.Models.OutputModels
{
    public class CoffeeMakerOutputModel : BaseProductOutputModel
    {
        public int NumberOfRecipes { get; set; }
        public int Volume { get; set; }
        public int NumberOfModes { get; set; }
    }
}
