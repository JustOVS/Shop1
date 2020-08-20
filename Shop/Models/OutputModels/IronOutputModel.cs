
namespace Shop.API.Models.OutputModels
{
    public class IronOutputModel : BaseProductOutputModel
    {
        public bool DryingMode { get; set; }
        public bool DescalingProtection { get; set; }
        public int NumberOfModes { get; set; }
    }
}
