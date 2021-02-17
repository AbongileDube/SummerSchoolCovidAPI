using SummerSchoolCovidAPI.Models;
using SummerSchoolCovidAPI.Models.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace SummerSchoolCovidAPI.Services
{
    private readonly CovidAPIContext _context;
    public class InfectedUserService :InfectedUser
    {
        public InfectedUserService(CovidAPIContext context)
        {
            _context = context;
        }
        public async Task<CovidCase> AddCovidCaseContact(CovidCaseContactDTO covidCaseContact)
        {
            var obj = new CovidCaseContact
            {
                Name = covidCaseContact.Name,
                Surname = covidCaseContact.Surname,
                Email = covidCaseContact.Email,
                MobileNumber = covidCaseContact.MobileNumber,
                Location = covidCaseContact.Location,
                Id = covidCaseContact.Id,

            };
            var entityAdded = await _context.CovidCases.AddAsync(obj);
            await _context.SaveChangesAsync();
            return entityAdded.Entity;
        }

        public Task DeleteInfectedUser(string id)
        {
            throw new NotImplementedException();
        }

        public Task<InfectedUser> UpdateInfectedUser(string id)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<InfectedUser>> GetInfectedUsers()
        {
            throw new NotImplementedException();
        }

        public Task<InfectedUser> UpdateInfectedUser(string id, InfectedUserDTO infectedUser)
        {
            throw new NotImplementedException();
        }
    }
}

    }
}
