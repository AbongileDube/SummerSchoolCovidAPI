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
    public class InfectedUserService : IInfectedUserService
    {
        private readonly CovidDbContext _context;

        public InfectedUserService(CovidDbContext covidAPIContext)
        {
            _context = covidAPIContext;
        }

        public async Task<InfectedUser> AddInfectedUser(InfectedUserDto infectedUser)
        {
            var obj = new InfectedUser
            {
                Name = infectedUser.Name,
                Surname = infectedUser.Surname,
                Email = infectedUser.Email,
                LocationId = infectedUser.LocationId,
                MobileNumber = infectedUser.MobileNumber,
                Infected = infectedUser.Infected,
                Id = infectedUser.Id,
            };
            var entityAdded = await _context.InfectedUsers.AddAsync(obj);
            await _context.SaveChangesAsync();
            return entityAdded.Entity;
        }

        public async Task DeleteInfectedUser(string id)
        {
            var entity = await _context.InfectedUsers.FindAsync(id);
            _context.InfectedUsers.Remove(entity);
            await _context.SaveChangesAsync();
        }

        public async Task<InfectedUser> GetInfectedUser(string id)
        {
            return await _context.InfectedUsers.FindAsync(id);
        }

        public async Task<IEnumerable<InfectedUser>> GetInfectedUsers()
        {
            return await _context.InfectedUsers.ToListAsync();
        }

        public async Task<InfectedUser> UpdateInfectedUser(string id, InfectedUserDto infectedUser)

        {
            var entity = await _context.InfectedUsers.FindAsync(id);
            if (entity == null)
            {
                throw new KeyNotFoundException($"Given Id:'{id}' is not found");
            }
            entity.Name = infectedUser.Name;
            entity.Surname = infectedUser.Surname;
            entity.LocationId = infectedUser.LocationId;
            entity.Infected = infectedUser.Infected;
            entity.MobileNumber = infectedUser.MobileNumber;
            entity.Email = infectedUser.Email;
            entity.Id = infectedUser.Id;
            await _context.SaveChangesAsync();
            return entity;
        }
    }
}