using System.Globalization;

namespace DIS_Project.DataModels
{
    public class WeatherCondition
    {
        public int WeatherConditionId { get; set; }
        public string Name { get; set; }
        public string Description  { get; set; }
        public string CreatedBy { get; set; }
        public DateTime CreatedDate { get; set; }
    }
}
