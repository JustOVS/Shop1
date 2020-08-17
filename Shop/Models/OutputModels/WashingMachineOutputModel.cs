

namespace Shop.API.Models.OutputModels
{
    public class WashingMachineOutputModel : BaseProductOutputModel
    {
        public bool DryingMode { get; set; }
        public int Volume { get; set; }
        public int NoiseLevel { get; set; }
    }
}
