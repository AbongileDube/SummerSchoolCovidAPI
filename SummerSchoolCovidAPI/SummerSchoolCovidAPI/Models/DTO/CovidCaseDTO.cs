using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SummerSchoolCovidAPI.Models.DTO
{
    public class CovidCaseDTO
    {
        public string Id { get; set; }
        public string InfectedUserId { get; set; }
        public string TestLocation { get; set; }
        public DateTime DateActioned { get; set; }
        public string DoctorName { get; set; }
        public string Secret { get; set; }
    }
}
