using SummerSchoolCovidAPI.Models;
using SummerSchoolCovidAPI.Models.DTO;
using SummerSchoolCovidAPI.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SummerSchoolCovidAPI.Services
{
    public class CovidCaseContactService : ICovidCaseContactService
    {
        private readonly CovidAPIContext _context;

        public CovidCaseContactService(CovidAPIContext context)
        {
            _context = context;
        }

        public async Task<CovidCaseContact> AddCovidCaseContact(CovidCaseContactDTO covidCaseContact)
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
            var entityAdded = await _context.CovidCaseContacts.AddAsync(obj);
            await _context.SaveChangesAsync();
            return entityAdded.Entity;
        }

        public Task DeleteCovidCaseContact(string id)
        {
            throw new NotImplementedException();
        }

        public Task<CovidCase> GetCovidCaseContact(string id)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<CovidCaseContact>> GetCovidCaseContact()
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<CovidCase>> GetCovidCaseContacts()
        {
            throw new NotImplementedException();
        }

        public Task<CovidCase> UpdateCovidCaseContact(string id, CovidCaseDTO covidCase)
        {
            throw new NotImplementedException();
        }

        public Task<CovidCaseContact> UpdateCovidCaseContact(string id, CovidCaseContactDTO covidCaseContact)
        {
            throw new NotImplementedException();
        }

        Task<CovidCaseContact> ICovidCaseContactService.GetCovidCaseContact(string id)
        {
            throw new NotImplementedException();
        }
    }
}