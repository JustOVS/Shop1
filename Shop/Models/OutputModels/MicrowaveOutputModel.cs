namespace Shop.API.Models.OutputModels
{
    public class MicrowaveOutputModel : BaseProductOutputModel
    {
        public int NumberOfRecipes { get; set; }
        public int Power { get; set; }
        public int NumberOfModes { get; set; }
    }
}
