using System.ComponentModel.DataAnnotations;

namespace DIS_Project.Dto
{
    public class CrashRecordDto
    {
        public int CrashId { get; set; }
        public string Email { get; set; }
        public DateTime CrashDateTime { get; set; }
        public int CrashYear { get; set; }
        public string CrashLocation { get; set; }
        public int RoadCharacterId { get; set; }
        public int RoadConfigurationId { get; set; }
        public int RoadConditionId { get; set; }
        public int WeatherConditionId { get; set; }
        public string Injuries { get; set; }
        public string? AdditionalInformation { get; set; }
        public int VehicleTypeId { get; set; }
        public string? RoadCharacterDescription { get; set; }
        public string? RoadConditionDescription { get; set; }
        public string? RoadConfigurationDescription { get; set; }
        public string? VehicleTypeDescription { get; set; }
        public string? WeatherConditionDescription { get; set; }
    }
}
