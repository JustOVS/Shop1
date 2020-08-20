
namespace Shop.API.Models.OutputModels
{
    public class MixerOutputModel : BaseProductOutputModel
    {
        public int NumberOfNozzles { get; set; }
        public int Power { get; set; }
        public bool DescalingProtection { get; set; }
    }
}
