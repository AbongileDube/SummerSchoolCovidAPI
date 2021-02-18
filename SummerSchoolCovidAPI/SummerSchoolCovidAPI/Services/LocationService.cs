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
    public class LocationService : ILocationService
    {
        private readonly CovidAPIContext _context;
        public LocationService (CovidAPIContext context)
        {
            _context = context;
        }

        public async Task<Location> AddLocation(LocationDTO location)
        {
            var obj = new Location
            {
                City = location.City,
                Suburb = location.Suburb,
                Province = location.Province,
                CNumberInfected = location.CNumberInfected,
        Id = location.Id
            };
            var entityAdded = await _context.Locations.AddAsync(obj);
            await _context.SaveChangesAsync();
            return entityAdded.Entity;
        }

        public async Task DeleteLocation(string id)
        {
            var entity = await _context.Locations.FindAsync(id);
            _context.Locations.Remove(entity);
            await _context.SaveChangesAsync();
        }

        public async Task<Location> GetLocation(string id)
        {
            return await _context.Locations.FindAsync(id);
        }

        public async Task<IEnumerable<Location>> GetLocations()
        {
            return await _context.Locations.ToListAsync();
        }

        public async Task<Location> UpdateLocation(string id, LocationDTO location)
        {
            var entity = await _context.Locations.FindAsync(id);
            if (entity == null)
            {
                throw new KeyNotFoundException($"Given Id:'{id}' is not found");
            }

            entity.City = location.City;
            entity.Suburb = location.Suburb;
            entity.Province = location.Province;
            entity.CNumberInfected = location.CNumberInfected;
            entity.Id = location.Id;
            await _context.SaveChangesAsync();
            return entity;
        }
    }
}
