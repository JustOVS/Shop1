
namespace Shop.API.Models.OutputModels
{
    public class KettleOutputModel : BaseProductOutputModel
    {
        public int Power { get; set; }
        public int Volume { get; set; }
        public bool DescalingProtection { get; set; }
    }
}
