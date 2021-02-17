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
            await _context.SaveChangesAsync();
            return entityAdded.Entity;
        }

        public async Task DeleteCovidCase(string id)
        {
            var entityAdded = await _context.CovidCases.FindAsync(id);
            await _context.SaveChangesAsync();
            return ;
        }

    }

        public async Task<CovidCase> GetCovidCase(string id)
        {
        var entityAdded = await _context.CovidCases.AddAsync(obj);
        await _context.SaveChangesAsync();
        return entityAdded.Entity;
    }

        public async Task<IEnumerable<CovidCase>> GetCovidCases()
        {
            var entityAdded = await _context.CovidCases.AddAsync(obj);
            await _context.SaveChangesAsync();
            return entityAdded.Entity;
        }

        public async Task<CovidCase> UpdateCovidCase(string id, CovidCaseDTO covidCase)
        {
            var entityAdded = await _context.CovidCases.AddAsync(obj);
            await _context.SaveChangesAsync();
            return entityAdded.Entity;
        }
    }
}