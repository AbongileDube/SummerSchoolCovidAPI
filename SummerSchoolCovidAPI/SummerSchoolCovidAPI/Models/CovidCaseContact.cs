using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SummerSchoolCovidAPI.Models
{
    public class CovidCaseContact
    {
        public string Id { get; set; }
        public string CovidCaseId { get; set; }
        public string InfectedUserId { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public string LocationId{ get; set; }
        [DataType(DataType.PhoneNumber)]
        public string MobileNumber { get; set; }
        [DataType(DataType.EmailAddress)]
        public string Email { get; set; }

        [ForeignKey("CovidCaseId")]
        public virtual CovidCase CovidCase { get; set; }
        [ForeignKey("InfectedUserId")]
        public virtual InfectedUser InfectedUser { get; set; }
    }
}
