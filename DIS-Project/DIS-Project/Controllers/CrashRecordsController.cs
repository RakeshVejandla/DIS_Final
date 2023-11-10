using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using DIS_Project.Data;
using DIS_Project.DataModels;
using DIS_Project.Dto;
using Microsoft.IdentityModel.Tokens;
using Newtonsoft.Json.Linq;
using Newtonsoft.Json;
using System.Net.Http;
using System.Security.Policy;
using System.Collections;
using System.ComponentModel;
using System.Reflection;
using System.Collections.Specialized;
using static System.Net.Mime.MediaTypeNames;
using PagedList;

namespace DIS_Project.Controllers
{
    public class CrashRecordsController : Controller
    {
        private readonly ApplicationDbContext _context;
        private readonly HttpClient httpClient;
        string apiUrl = "https://data.townofcary.org/api/explore/v2.1/catalog/datasets/cpd-crash-incidents/records?limit=100";


        public CrashRecordsController(ApplicationDbContext context, HttpClient httpClient)
        {
            this._context = context;
            this.httpClient = httpClient;
        }

        // GET: CrashRecords
        public async Task<IActionResult> Index(CrashRecordViewModel crashRecordViewModel)
        {
            await GetApiData();

            var crashRecords = await _context.CrashRecord
                .Include(x => x.RoadCharacter)
                .Include(x => x.RoadCondition)
                .Include(x => x.RoadConfiguration)
                .Include(x => x.WeatherCondition)
                .Include(x => x.VehicleType)
                .Select(cr => new CrashRecordDto
            {
                CrashId = cr.CrashRecordId,
                CrashYear = cr.CrashYear.Value,
                CrashDateTime = cr.CrashDateTime.Value,
                CrashLocation = cr.CrashLocation,
                Email = cr.Email,
                RoadCharacterId = cr.RoadCharacterId.Value,
                RoadConditionId = cr.RoadConditionId.Value,
                RoadConfigurationId = cr.RoadConfigurationId.Value,
                AdditionalInformation = cr.AdditionalInformation,
                Injuries = cr.Injuries,
                VehicleTypeId = cr.VehicleTypeId.Value,
                WeatherConditionId = cr.WeatherConditionId.Value,
                RoadCharacterDescription = cr.RoadCharacter.Name,
                RoadConditionDescription = cr.RoadCondition.Name,
                RoadConfigurationDescription = cr.RoadConfiguration.Name,
                VehicleTypeDescription = cr.VehicleType.Name,
                WeatherConditionDescription = cr.WeatherCondition.Name
            }).OrderByDescending(x => x.CrashId).ToListAsync();

            if (crashRecordViewModel.CrashId != null && crashRecordViewModel.CrashId !=0)
            {
                crashRecords = crashRecords.Where(x => x.CrashId == crashRecordViewModel.CrashId).ToList();
            }

            if (!crashRecordViewModel.Email.IsNullOrEmpty())
            {
                crashRecords = crashRecords.Where(x => x.Email.Contains(crashRecordViewModel.Email, StringComparison.OrdinalIgnoreCase)).ToList();
            }

            if (crashRecordViewModel.RoadConditionId != null && crashRecordViewModel.RoadConditionId != 0)
            {
                crashRecords = crashRecords.Where(x => x.RoadConditionId == crashRecordViewModel.RoadConditionId).ToList();
            }

            if (crashRecordViewModel.RoadCharacterId != null && crashRecordViewModel.RoadCharacterId != 0)
            {
                crashRecords = crashRecords.Where(x => x.RoadCharacterId == crashRecordViewModel.RoadCharacterId).ToList();
            }

            if (crashRecordViewModel.WeatherConditionId != null && crashRecordViewModel.WeatherConditionId != 0)
            {
                crashRecords = crashRecords.Where(x => x.WeatherConditionId == crashRecordViewModel.WeatherConditionId).ToList();
            }


            var crashSearchViewModel = new CrashSearchViewModel
            {
                RoadCharacters = await GetRoadCharacters(),
                RoadConditions = await GetRoadConditions(),
                WeatherConditions = await GetWeatherConditions(),
                CrashRecord = crashRecords,
            }; 

            return View(crashSearchViewModel);
        }

        public async Task GetApiData()
        {
            HttpResponseMessage response = await httpClient.GetAsync(apiUrl);

            if (response.IsSuccessStatusCode)
            {
                string jsonResponse = await response.Content.ReadAsStringAsync();

                var jsonObject = JsonConvert.DeserializeObject<JObject>(jsonResponse);

                var records = jsonObject["results"];

                List<CrashRecord> crashRecords = new List<CrashRecord>();
                foreach (var record in records)
                {
                    var existingRecord = await _context.CrashRecord
                        .Where(x => x.TamainId == (int?)record["tamainid"])
                        .FirstOrDefaultAsync();
                    if (existingRecord == null)
                    {
                        var crash = new CrashRecord
                        {
                            CrashYear = (int?)record["year"],
                            CrashLocation = record["location_description"]?.ToString(),
                            CrashDateTime = (DateTime?)record["crash_date"],
                            Email = " ",
                            AdditionalInformation = " ",
                            Injuries = "",
                            TamainId = (int?)record["tamainid"],
                            RoadCharacterId = GetRoadCharacterId(record["rdcharacter"]?.ToString()),
                            RoadConditionId = GetRoadConditionId(record["rdcondition"]?.ToString()),
                            RoadConfigurationId = GetRoadCofigurationId(record["rdconfigur"]?.ToString()),
                            VehicleTypeId = GetVehicleTypeId(record["vehicle1"]?.ToString()),
                            WeatherConditionId = GetWeatherConditionId(record["weather"]?.ToString()),
                            CreatedBy = "System",
                            CreatedDate = DateTime.Now
                        };
                        crashRecords.Add(crash);
                    }
                }

                await _context.AddRangeAsync(crashRecords);
                await _context.SaveChangesAsync();
            }
        }
        

        // get int value from Api
        public int GetRoadCharacterId(string? temp)
        {
            int recordInt = 5;
            if (!temp.IsNullOrEmpty())
            {
                JArray jsonArray = JArray.Parse(temp);
                
                if (jsonArray.Count > 0)
                {
                    var recordValue = jsonArray[0].ToString();

                    recordInt = recordValue.Equals("Straight", StringComparison.OrdinalIgnoreCase) ? 1 :
                        recordValue.Equals("Level", StringComparison.OrdinalIgnoreCase) ? 2 :
                        recordValue.Equals("Curve", StringComparison.OrdinalIgnoreCase) ? 3 :
                        recordValue.Equals("HillCrest", StringComparison.OrdinalIgnoreCase) ? 4 : 5;
                }
            }
            return recordInt;
        }

        public int GetRoadConditionId(string? temp)
        {
            int recordInt = 5;
            if (!temp.IsNullOrEmpty())
            {
                    recordInt = temp.Equals("Dry", StringComparison.OrdinalIgnoreCase) ? 1 :
                        temp.Equals("Wet", StringComparison.OrdinalIgnoreCase) ? 2 :
                        temp.Equals("Ice", StringComparison.OrdinalIgnoreCase) ? 3 :
                        temp.Equals("Snow", StringComparison.OrdinalIgnoreCase) ? 4 : 5;
                
            }
            return recordInt;
        }

        public int GetRoadCofigurationId(string? temp)
        {
            int recordInt = 4;
            if (!temp.IsNullOrEmpty())
            {
                JArray jsonArray = JArray.Parse(temp);
                if (jsonArray.Count > 0)
                {
                    var recordValue = jsonArray[0].ToString();

                    recordInt = recordValue.Equals("Two-way", StringComparison.OrdinalIgnoreCase) ? 1 :
                        recordValue.Equals("Not Divided", StringComparison.OrdinalIgnoreCase) ? 2 :
                        recordValue.Equals("Divided", StringComparison.OrdinalIgnoreCase) ? 3 : 4;
                }
            }
            return recordInt;
        }

        public int GetWeatherConditionId(string? temp)
        {
            int recordInt = 4;
            if (!temp.IsNullOrEmpty())
            {
                    recordInt = temp.Equals("Clear", StringComparison.OrdinalIgnoreCase) ? 1 :
                        temp.Equals("Coludy", StringComparison.OrdinalIgnoreCase) ? 2 :
                        temp.Equals("Rain", StringComparison.OrdinalIgnoreCase) ? 3 : 4;
                
            }
            return recordInt;
        }

        public int GetVehicleTypeId(string? temp)
        {
            int recordInt = 5;
            if (!temp.IsNullOrEmpty())
            {
                
                    recordInt = temp.Equals("Passenger Car", StringComparison.OrdinalIgnoreCase) ? 1 :
                        temp.Equals("Sport Utility", StringComparison.OrdinalIgnoreCase) ? 2 :
                        temp.Equals("Pickup", StringComparison.OrdinalIgnoreCase) ? 3 :
                        temp.Equals("Van", StringComparison.OrdinalIgnoreCase) ? 4 : 5;
                
            }
            return recordInt;
        }

        // Getting string from api
        public string GetStringFromApi(string temp)
        {
            JArray jsonArray = JArray.Parse(temp);
            string recordValue = "";
            if (jsonArray.Count > 0)
            {
                recordValue = jsonArray[0].ToString();
            }
            return recordValue;
        }

        public static string GetEnumDescription(Enum value)
        {
            FieldInfo fi = value.GetType().GetField(value.ToString());

            DescriptionAttribute[] attributes =
                (DescriptionAttribute[])fi.GetCustomAttributes(
                    typeof(DescriptionAttribute),
                    false);

            if (attributes != null && attributes.Length > 0)
                return attributes[0].Description;
            else
                return value.ToString();
        }


        // GET: CrashRecords/Details/5
        public async Task<ActionResult> Details(int id)
        {
            var crashRecord = await _context.CrashRecord.FindAsync(id);
            if (crashRecord == null)
            {
                return NotFound();
            }

            CrashRecordDto crashRecordDto = new CrashRecordDto
            {
                CrashId = crashRecord.CrashRecordId,
                CrashDateTime = crashRecord.CrashDateTime.Value,
                CrashYear = crashRecord.CrashYear.Value,
                CrashLocation = crashRecord.CrashLocation,
                AdditionalInformation = crashRecord.AdditionalInformation,
                Email = crashRecord.Email,
                Injuries = crashRecord.Injuries,
                VehicleTypeId = crashRecord.VehicleTypeId.Value,
                RoadCharacterId = crashRecord.RoadCharacterId.Value,
                RoadConditionId = crashRecord.RoadConditionId.Value,
                RoadConfigurationId = crashRecord.RoadConfigurationId.Value,
                WeatherConditionId = crashRecord.WeatherConditionId.Value
            };
            ViewBag.WeatherConditionDescription = _context.WeatherCondition.FirstOrDefault(x => x.WeatherConditionId == crashRecord.WeatherConditionId)?.Name;
            ViewBag.RoadConditionDescription = _context.RoadCondition.FirstOrDefault(x => x.RoadConditionId == crashRecord.RoadConditionId)?.Name;
            ViewBag.RoadCharacterDescription = _context.RoadCharacter.FirstOrDefault(x => x.RoadCharacterId == crashRecord.RoadCharacterId)?.Name;
            ViewBag.VehicleTypeDescription = _context.VehicleType.FirstOrDefault(x => x.VehicleTypeId == crashRecord.VehicleTypeId)?.Name;
            ViewBag.RoadConfigurationDescription = _context.RoadConfiguration.FirstOrDefault(x => x.RoadConfigurationId == crashRecord.RoadConfigurationId)?.Name;
            return View(crashRecordDto);
        }


        public async Task<IActionResult> Create()
        {
            var crashRecordViewModel = new CrashRecordViewModel
            {
                RoadCharacters = await GetRoadCharacters(),
                RoadConditions = await GetRoadConditions(),
                WeatherConditions = await GetWeatherConditions(),
                RoadConfigurations = await GetRoadConfigurations(),
                VehicleTypes = await GetVehicleTypes(),
            };
            return View(crashRecordViewModel);
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(CrashRecordViewModel crashRecord)
        {
            if (ModelState.IsValid)
            {
                CrashRecord newCrashRecord = new CrashRecord
                {
                    Email = crashRecord.Email,
                    TamainId = 0,
                    CrashDateTime = crashRecord.CrashDateTime,
                    CrashLocation = crashRecord.CrashLocation,
                    Injuries = crashRecord.Injuries,
                    AdditionalInformation = crashRecord.AdditionalInformation,
                    RoadCharacterId = crashRecord.RoadCharacterId,
                    RoadConditionId = crashRecord.RoadConditionId,
                    RoadConfigurationId = crashRecord.RoadConfigurationId,
                    WeatherConditionId = crashRecord.WeatherConditionId,
                    VehicleTypeId = crashRecord.VehicleTypeId,
                    CrashYear = crashRecord.CrashDateTime.Year,
                    CreatedBy = "Admin",
                    CreatedDate = DateTime.Now
                };
                _context.CrashRecord.Add(newCrashRecord);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            
            var crashRecordViewModel = new CrashRecordViewModel
            {
                RoadCharacters = await GetRoadCharacters(),
                RoadConditions = await GetRoadConditions(),
                WeatherConditions = await GetWeatherConditions(),
                RoadConfigurations = await GetRoadConfigurations(),
                VehicleTypes = await GetVehicleTypes(),
            };

            return View(crashRecordViewModel);
        }

        // GET: CrashRecords/Edit/5
        public async Task<ActionResult> Edit(int id)
        {
            var crashRecord = await _context.CrashRecord.FindAsync(id);
            if (crashRecord == null)
            {
                return NotFound();
            }

            ViewBag.WeatherConditions = new SelectList(_context.WeatherCondition, "WeatherConditionId", "Name", crashRecord.WeatherConditionId);
            ViewBag.RoadConditions = new SelectList(_context.RoadCondition, "RoadConditionId", "Name", crashRecord.RoadConditionId);
            ViewBag.RoadCharacters = new SelectList(_context.RoadCondition, "RoadConditionId", "Name", crashRecord.RoadConditionId);
            ViewBag.RoadConfigurations = new SelectList(_context.RoadConfiguration, "RoadConfigurationId", "Name", crashRecord.RoadConfigurationId);
            ViewBag.VehicleTypes = new SelectList(_context.VehicleType, "VehicleTypeId", "Name", crashRecord.VehicleTypeId);
            var viewModel = new CrashRecordDto
            {
                CrashId = crashRecord.CrashRecordId,
                CrashDateTime = crashRecord.CrashDateTime.Value,
                CrashLocation = crashRecord.CrashLocation,
                CrashYear = crashRecord.CrashYear.Value,
                Email = crashRecord.Email,
                Injuries = crashRecord.Injuries,
                AdditionalInformation = crashRecord.AdditionalInformation,
                RoadCharacterId = crashRecord.RoadCharacterId.Value,
                RoadConditionId = crashRecord.RoadConditionId.Value,
                RoadConfigurationId = crashRecord.RoadConfigurationId.Value,
                VehicleTypeId = crashRecord.VehicleTypeId.Value,
                WeatherConditionId = crashRecord.WeatherConditionId.Value
            };
            return View(viewModel);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit(int id, CrashRecordDto crashRecord)
        {
            if (id != crashRecord.CrashId)
            {
                return NotFound();
            }

            var dbCrashRecord = _context.CrashRecord.Where(x => x.CrashRecordId == crashRecord.CrashId).FirstOrDefault();

            if (ModelState.IsValid )
            {
                if(dbCrashRecord != null)
                {
                    dbCrashRecord.CrashRecordId = crashRecord.CrashId;
                    dbCrashRecord.Email = crashRecord.Email;
                    dbCrashRecord.CrashDateTime = crashRecord.CrashDateTime;
                    dbCrashRecord.CrashLocation = crashRecord.CrashLocation;
                    dbCrashRecord.Injuries = crashRecord.Injuries;
                    dbCrashRecord.AdditionalInformation = crashRecord.AdditionalInformation;
                    dbCrashRecord.RoadCharacterId = crashRecord.RoadCharacterId;
                    dbCrashRecord.RoadConditionId = crashRecord.RoadConditionId;
                    dbCrashRecord.RoadConfigurationId = crashRecord.RoadConfigurationId;
                    dbCrashRecord.WeatherConditionId = crashRecord.WeatherConditionId;
                    dbCrashRecord.VehicleTypeId = crashRecord.VehicleTypeId;
                    dbCrashRecord.CrashYear = crashRecord.CrashDateTime.Year;
                    dbCrashRecord.CreatedBy = "Admin";
                    dbCrashRecord.CreatedDate = DateTime.Now;

                }

                _context.Update(dbCrashRecord);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(crashRecord);
        }

        // GET: CrashRecords/Delete/5
        public async Task<ActionResult> Delete(int id)
        {
            var crashRecord = await _context.CrashRecord.FindAsync(id);
            if (crashRecord == null)
            {
                return NotFound();
            }
            ViewBag.WeatherConditions = new SelectList(_context.WeatherCondition, "WeatherConditionId", "Name", crashRecord.WeatherConditionId);
            ViewBag.RoadConditions = new SelectList(_context.RoadCondition, "RoadConditionId", "Name", crashRecord.RoadConditionId);
            ViewBag.RoadCharacters = new SelectList(_context.RoadCondition, "RoadConditionId", "Name", crashRecord.RoadConditionId);
            ViewBag.RoadConfigurations = new SelectList(_context.RoadConfiguration, "RoadConfigurationId", "Name", crashRecord.RoadConfigurationId);
            ViewBag.VehicleTypes = new SelectList(_context.VehicleType, "VehicleTypeId", "Name", crashRecord.VehicleTypeId);
            return View(crashRecord);
        }

        // POST: CrashRecords/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed(int id)
        {
            var crashRecord = await _context.CrashRecord.FindAsync(id);
            _context.CrashRecord.Remove(crashRecord);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool CrashRecordExists(int id)
        {
          return (_context.CrashRecord?.Any(e => e.CrashRecordId == id)).GetValueOrDefault();
        }



        public async Task<List<SelectListItem>> GetRoadCharacters()
        {
            List<SelectListItem> roadCharacter = new List<SelectListItem>();
            var roadCharactersList = await _context.RoadCharacter.ToListAsync();
            if(!roadCharactersList.IsNullOrEmpty())
            {
                roadCharacter =  roadCharactersList.Select(roadCharacter => new SelectListItem
                {
                    Value = roadCharacter.RoadCharacterId.ToString(),
                    Text = roadCharacter.Name
                }).ToList();

                return roadCharacter;
            }
            return roadCharacter;
        }

        public async Task<List<SelectListItem>> GetRoadConditions()
        {
            List<SelectListItem> roadCondition = new List<SelectListItem>();
            var roadConditionsList = await _context.RoadCondition.ToListAsync();
            if (!roadConditionsList.IsNullOrEmpty())
            {
                 roadCondition = roadConditionsList.Select(roadCondition => new SelectListItem
                {
                    Value = roadCondition.RoadConditionId.ToString(),
                    Text = roadCondition.Name
                }).ToList();
                return roadCondition;
            }
            return roadCondition;
        }

        public async Task<List<SelectListItem>> GetRoadConfigurations()
        {
            List<SelectListItem> roadConfiguration = new List<SelectListItem>();
            var roadConfigurationList = await _context.RoadConfiguration.ToListAsync();
            if (!roadConfigurationList.IsNullOrEmpty())
            {
                roadConfiguration = roadConfigurationList.Select(roadConfiguration => new SelectListItem
                {
                    Value = roadConfiguration.RoadConfigurationId.ToString(),
                    Text = roadConfiguration.Name
                }).ToList();

                return roadConfiguration;
            }
            return roadConfiguration;
        }

        public async Task<List<SelectListItem>> GetVehicleTypes()
        {
            List<SelectListItem> vehicleType = new List<SelectListItem>();
            var vehicleTypeList = await _context.VehicleType.ToListAsync();
            if (!vehicleTypeList.IsNullOrEmpty())
            {
                vehicleType = vehicleTypeList.Select(vehicleType => new SelectListItem
                {
                    Value = vehicleType.VehicleTypeId.ToString(),
                    Text = vehicleType.Name
                }).ToList();
                return vehicleType;
            }
            return vehicleType;
        }

        public async Task<List<SelectListItem>> GetWeatherConditions() 
        {
            List<SelectListItem> weatherCondition = new List<SelectListItem>();
            var weatherConditionList = await _context.WeatherCondition.ToListAsync();
            if (!weatherConditionList.IsNullOrEmpty())
            {
                weatherCondition = weatherConditionList.Select(weatherCondition => new SelectListItem
                {
                    Value = weatherCondition.WeatherConditionId.ToString(),
                    Text = weatherCondition.Name
                }).ToList();
                return weatherCondition;
            }
            return weatherCondition;
        }
    }
}
