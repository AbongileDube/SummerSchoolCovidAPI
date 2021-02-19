using Microsoft.EntityFrameworkCore;
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
                LocationId =covidCase.LocationId,
                InfectedUserId = covidCase.InfectedUserId,
                Id = covidCase.Id
                
                
            };
            var entityAdded = await _context.CovidCases.AddAsync(obj);
            await _context.SaveChangesAsync();
            return entityAdded.Entity;
        }

        public async Task DeleteCovidCase(string id)
        {
            var entity = await _context.CovidCases.FindAsync(id);
            _context.CovidCases.Remove(entity);
            await _context.SaveChangesAsync();
        }

        public async Task<CovidCase> GetCovidCase(string id)
        {
            return await _context.CovidCases.FindAsync(id);
        }

        public async Task<IEnumerable<CovidCase>> GetCovidCases()
        {
            return await _context.CovidCases.ToListAsync();
        }

        public async Task<CovidCase> UpdateCovidCase(string id, CovidCaseDTO covidCase)
        {
            var entity = await _context.CovidCases.FindAsync(id);
            if (entity == null)
            {
                throw new KeyNotFoundException($"Given Id:'{id}' is not found");
            }

            entity.DoctorName = covidCase.DoctorName;
            entity.LocationId = covidCase.LocationId;
            entity.InfectedUserId = covidCase.InfectedUserId;
           
            await _context.SaveChangesAsync();
            return entity;
        }
    }
}