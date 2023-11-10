using Microsoft.AspNetCore.Mvc.Rendering;
using System.ComponentModel.DataAnnotations;

namespace DIS_Project.Dto
{
    public class CrashRecordViewModel
    {
        public int CrashId { get; set; }
        public string Email { get; set; }
        public DateTime CrashDateTime { get; set; }
        public string CrashLocation { get; set; }
        public int RoadCharacterId { get; set; }
        public int RoadConfigurationId { get; set; }

        public int RoadConditionId { get; set; }
        public int WeatherConditionId { get; set; }
        public string Injuries { get; set; }
        public string AdditionalInformation { get; set; }
        public int VehicleTypeId { get; set; }

        // SelectListItems for Dropdowns
        public List<SelectListItem>? RoadCharacters { get; set; }
        public List<SelectListItem>? RoadConfigurations { get; set; }
        public List<SelectListItem>? RoadConditions { get; set; }
        public List<SelectListItem>? WeatherConditions { get; set; }
        public List<SelectListItem>? VehicleTypes { get; set; }

    }
}
