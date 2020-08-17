

namespace Shop.API.Models.OutputModels
{
    public class VacuumCleanerOutputModel :BaseProductOutputModel
    {
        public int NumberOfNozzles { get; set; }
        public int Power { get; set; }
        public int NoiseLevel { get; set; }
    }
}
