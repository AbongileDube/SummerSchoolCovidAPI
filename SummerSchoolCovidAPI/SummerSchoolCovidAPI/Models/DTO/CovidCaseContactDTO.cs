using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SummerSchoolCovidAPI.Models.DTO
{
    public class CovidCaseContactDTO
    {
        public string Id { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public string LocationId { get; set; }
        [DataType(DataType.PhoneNumber)]
        public string MobileNumber { get; set; }
        [DataType(DataType.EmailAddress)]
        public string Email { get; set; }
        public string InfectedUserId { get; internal set; }
    }
}
