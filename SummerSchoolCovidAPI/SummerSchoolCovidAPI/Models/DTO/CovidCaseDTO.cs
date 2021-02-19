using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SummerSchoolCovidAPI.Models.DTO
{
    public class CovidCaseDto
    {
        public string Id { get; set; }
        public string InfectedUserId { get; set; }
        public string LocationId { get; set; }
        public DateTime DateActioned { get; set; }
        public string DoctorName { get; set; }
        public bool Infected { get; set; }
    }
}