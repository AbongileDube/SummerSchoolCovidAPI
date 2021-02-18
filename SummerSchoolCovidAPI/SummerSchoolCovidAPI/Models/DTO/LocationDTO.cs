using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using SummerSchoolCovidAPI.Models;
using SummerSchoolCovidAPI.Models.DTO;

namespace SummerSchoolCovidAPI.Models.DTO
{
    public class LocationDTO
    {
        public string Id { get; set; }
        public string City { get; set; }
        public string Suburb { get; set; }
        public string Province { get; set; }
        public int CNumberInfected { get; set; } //current Number of people infected
    }
}
