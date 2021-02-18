using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SummerSchoolCovidAPI.Models
{
    public class CovidCase
    {
        public string Id { get; set; }
        public string InfectedUserId { get; set; }
        public string TestLocation { get; set; }
        public DateTime DateActioned { get; set; }
        public string DoctorName { get; set; }
       
        [ForeignKey("InfectedUserId")]
        public virtual InfectedUser InfectedUser { get; set; }
        [ForeignKey("LocationId")]
        public virtual Location Location { get; set; }
    }
}
