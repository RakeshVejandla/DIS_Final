//using DIS_Project.Data;
using DIS_Project.DataModels;
using Microsoft.EntityFrameworkCore;
using System.Linq;

namespace DIS_Project.Models
{
    public class SeedData
    {

        //GetRoadCharacters
        public static List<RoadCharacter> GetRoadCharacters()
        {
            return new List<RoadCharacter>
            {
                new RoadCharacter
                {
                    RoadCharacterId = 1,
                    Name = "Straight",
                    Description = "Straight",
                    CreatedBy = "System",
                    CreatedDate = DateTime.Now
                },
                new RoadCharacter
                {
                    RoadCharacterId = 2,
                    Name = "Level",
                    Description = "Level",
                    CreatedBy = "System",
                    CreatedDate = DateTime.Now
                },
                new RoadCharacter
                {
                    RoadCharacterId = 3,
                    Name = "Curve",
                    Description = "Curve",
                    CreatedBy = "System",
                    CreatedDate = DateTime.Now
                },
                new RoadCharacter
                {
                    RoadCharacterId = 4,
                    Name = "HillCrest",
                    Description = "HillCrest",
                    CreatedBy = "System",
                    CreatedDate = DateTime.Now
                },
                new RoadCharacter
                {
                    RoadCharacterId = 5,
                    Name = "Other",
                    Description = "Other",
                    CreatedBy = "System",
                    CreatedDate = DateTime.Now
                }
            };
        }

        //GetRoadConditions
        public static List<RoadCondition> GetRoadConditions()
        {
            return new List<RoadCondition>
            {
                new RoadCondition 
                { 
                    RoadConditionId = 1,
                    Name = "Dry",
                    Description = "Dry",
                    CreatedBy = "System",
                    CreatedDate = DateTime.Now
                },
                new RoadCondition
                {
                    RoadConditionId = 2,
                    Name = "Wet",
                    Description = "Wet",
                    CreatedBy = "System",
                    CreatedDate = DateTime.Now
                },
                 new RoadCondition
                {
                    RoadConditionId = 3,
                    Name = "Ice",
                    Description = "Ice",
                    CreatedBy = "System",
                    CreatedDate = DateTime.Now
                },
                new RoadCondition
                {
                    RoadConditionId = 4,
                    Name = "Snow",
                    Description = "Snow",
                    CreatedBy = "System",
                    CreatedDate = DateTime.Now
                },
                 new RoadCondition
                {
                    RoadConditionId = 5,
                    Name = "UnKnown",
                    Description = "UnKnown",
                    CreatedBy = "System",
                    CreatedDate = DateTime.Now
                }
            };
        }

        //GetRoadConfigurations
        public static List<RoadConfiguration> GetRoadConfigurations()
        {
            return new List<RoadConfiguration>
            {
                new RoadConfiguration
                {
                    RoadConfigurationId = 1,
                    Name = "Two-Way",
                    Description = "Two-Way",
                    CreatedBy = "System",
                    CreatedDate = DateTime.Now
                },
                new RoadConfiguration
                {
                    RoadConfigurationId = 2,
                    Name = "Not Divided",
                    Description = "Not Divided",
                    CreatedBy = "System",
                    CreatedDate = DateTime.Now
                },
                new RoadConfiguration
                {
                    RoadConfigurationId = 3,
                    Name = "Divided",
                    Description = "Divided",
                    CreatedBy = "System",
                    CreatedDate = DateTime.Now
                },
                new RoadConfiguration
                {
                    RoadConfigurationId = 4,
                    Name = "Other",
                    Description = "Other",
                    CreatedBy = "System",
                    CreatedDate = DateTime.Now
                }
            };
        }

        //GetVehicleTypes
        public static List<VehicleType> GetVehicleTypes()
        {
            return new List<VehicleType>
            {
                new VehicleType
                {
                    VehicleTypeId = 1,
                    Name = "Passenger",
                    Description = "Passenger",
                    CreatedBy = "System",
                    CreatedDate = DateTime.Now
                },
                new VehicleType
                {
                    VehicleTypeId = 2,
                    Name = "Sport",
                    Description = "Sport",
                    CreatedBy = "System",
                    CreatedDate = DateTime.Now
                },
                new VehicleType
                {
                    VehicleTypeId = 3,
                    Name = "PickUp",
                    Description = "PickUp",
                    CreatedBy = "System",
                    CreatedDate = DateTime.Now
                },
                new VehicleType
                {
                    VehicleTypeId = 4,
                    Name = "Van",
                    Description = "Van",
                    CreatedBy = "System",
                    CreatedDate = DateTime.Now
                },
                new VehicleType
                {
                    VehicleTypeId = 5,
                    Name = "Unknown",
                    Description = "Unknown",
                    CreatedBy = "System",
                    CreatedDate = DateTime.Now
                }
            };
        }

        //GetWeatherConditions
        public static List<WeatherCondition> GetWeatherConditions()
        {
            return new List<WeatherCondition>
            {
                new WeatherCondition
                {
                    WeatherConditionId = 1,
                    Name = "Clear",
                    Description= "Clear",
                    CreatedBy= "System",
                    CreatedDate = DateTime.Now
                },
                new WeatherCondition
                {
                    WeatherConditionId = 2,
                    Name = "Cloudy",
                    Description= "Cloudy",
                    CreatedBy= "System",
                    CreatedDate = DateTime.Now
                },
                new WeatherCondition
                {
                    WeatherConditionId = 3,
                    Name = "Rain",
                    Description= "Rain",
                    CreatedBy= "System",
                    CreatedDate = DateTime.Now
                },
                new WeatherCondition
                {
                    WeatherConditionId = 4,
                    Name = "Other",
                    Description= "Other",
                    CreatedBy= "System",
                    CreatedDate = DateTime.Now
                }
            };
        }
    }
}
