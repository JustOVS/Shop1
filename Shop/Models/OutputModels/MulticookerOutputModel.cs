
namespace Shop.API.Models.OutputModels
{
    public class MulticookerOutputModel : BaseProductOutputModel
    {
        public int NumberOfRecipes { get; set; }
        public int Volume { get; set; }
        public bool DescalingProtection { get; set; }
    }
}
