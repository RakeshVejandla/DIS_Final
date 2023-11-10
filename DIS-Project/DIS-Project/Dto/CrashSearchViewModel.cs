using Microsoft.AspNetCore.Mvc.Rendering;
using PagedList;

namespace DIS_Project.Dto
{
    public class CrashSearchViewModel
    {
        public int CrashId { get; set; }
        public string Email { get; set; }
        public int RoadCharacterId { get; set; }
        public string? RoadCharaterDescription { get; set; }
        public int RoadConditionId { get; set; }
        public string? RoadConditionDescription { get; set; }
        public int WeatherConditionId { get; set; }
        public string? WeatherConditionDescription { get; set; }
        public List<CrashRecordDto> CrashRecord { get; set; }
        public List<SelectListItem> RoadCharacters { get; set; }
        public List<SelectListItem> RoadConditions { get; set; }
        public List<SelectListItem> WeatherConditions { get; set; }
        public List<SelectListItem> VehicleTypes { get; set; }
        public List<SelectListItem> RoadConfigurations { get; set; }
    }
}
