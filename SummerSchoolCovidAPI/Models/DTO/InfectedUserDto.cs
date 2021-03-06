﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace SummerSchoolCovidAPI.Models.DTO
{
    public class InfectedUserDto
    {
        public string Id { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public string LocationId { get; set; }

        [DataType(DataType.PhoneNumber)]
        public string MobileNumber { get; set; }

        public string Email { get; set; }
        public bool Infected { get; set; }
    }
}