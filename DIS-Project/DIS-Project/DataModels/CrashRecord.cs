using Microsoft.EntityFrameworkCore;

namespace DIS_Project.DataModels
{
    public class CrashRecord
    {

        public int CrashRecordId { get; set; }
        public string? Email { get; set; }
        public DateTime? CrashDateTime { get; set; }
        public int? CrashYear { get; set; }
        public string? CrashLocation { get; set; }
        public int? RoadCharacterId { get; set; }
        public int? RoadConfigurationId { get; set; }
        public int? RoadConditionId { get; set; }
        public int? WeatherConditionId { get; set; }
        public string? Injuries { get; set; }
        public string? AdditionalInformation { get; set; }
        public int? VehicleTypeId { get; set; }
        public int? TamainId { get; set; }
        public string CreatedBy { get; set; }
        public DateTime CreatedDate { get; set; }

        public RoadCharacter RoadCharacter { get; set; }
        public RoadConfiguration RoadConfiguration { get; set; }
        public RoadCondition RoadCondition { get; set; }
        public WeatherCondition WeatherCondition { get; set; }
        public VehicleType VehicleType { get; set; }
    }
}
