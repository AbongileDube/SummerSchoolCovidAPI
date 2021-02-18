using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace SummerSchoolCovidAPI.Models
{
    public class InfectedUser
    {
        public string Id { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public string LocationId { get; set; }
       
        [DataType(DataType.PhoneNumber)]
        public string MobileNumber { get; set; }
        [DataType(DataType.EmailAddress)]
        
        public string Email { get; set; }
        public bool Infected { get; set; }
        [ForeignKey("LocationId")]
        public virtual Location Location { get; set; }



    }
}
