using SummerSchoolCovidAPI.Interfaces;
using SummerSchoolCovidAPI.Models;
using SummerSchoolCovidAPI.Models.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SummerSchoolCovidAPI.Services
{
    public class CovidCaseService : ICovidCaseService
    {
        private readonly CovidAPIContext _context;
        public CovidCaseService(CovidAPIContext context)
        {
            _context = context;
        }

        public async Task<CovidCase> AddCovidCase(CovidCaseDTO covidCase)
        {
            var obj = new CovidCase
            {
                DateActioned = DateTime.Now,
                DoctorName = covidCase.DoctorName,
                TestLocation = covidCase.TestLocation,
                InfectedUserId = covidCase.InfectedUserId,
                Id = covidCase.Id
            };
            var entityAdded = await _context.CovidCases.AddAsync(obj);
            return entityAdded.Entity;
        }

        public Task DeleteCovidCase(string id)
        {
            throw new NotImplementedException();
        }

        public Task<CovidCase> GetCovidCase(string id)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<CovidCase>> GetCovidCases()
        {
            throw new NotImplementedException();
        }

        public Task<CovidCase> UpdateCovidCase(string id, CovidCaseDTO covidCase)
        {
            throw new NotImplementedException();
        }
    }
}