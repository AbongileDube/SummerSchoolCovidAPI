using SummerSchoolCovidAPI.Models;
using SummerSchoolCovidAPI.Models.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using SummerSchoolCovidAPI.Interfaces;

namespace SummerSchoolCovidAPI.Services
{
    public class InfectedUserService : IInfectedUserService
    {
        private readonly CovidAPIContext _context;

        public InfectedUserService(CovidAPIContext context)
        {
            _context = context;
        }

        public Task<InfectedUser> AddInfectedUser(InfectedUserDTO infectedUser)
        {
            throw new NotImplementedException();
        }

        public Task DeleteInfectedUser(string id)
        {
            throw new NotImplementedException();
        }

        public Task<InfectedUser> GetInfectedUser(string id)
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