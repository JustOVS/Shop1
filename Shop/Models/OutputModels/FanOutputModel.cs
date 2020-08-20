
namespace Shop.API.Models.OutputModels
{
    public class FanOutputModel : BaseProductOutputModel
    {
        public int AirSpeed { get; set; }
        public int Power { get; set; }
        public int NoiseLevel { get; set; }
    }
}
