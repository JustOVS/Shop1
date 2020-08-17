
namespace Shop.API.Models.OutputModels
{
    public class HairdryerOutputModel : BaseProductOutputModel
    {
        public int AirSpeed { get; set; }
        public bool DryingMode { get; set; }
        public int NumberOfNozzles { get; set; }
    }
}
