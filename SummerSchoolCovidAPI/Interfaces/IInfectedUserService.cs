using SummerSchoolCovidAPI.Models;
using SummerSchoolCovidAPI.Models.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SummerSchoolCovidAPI.Interfaces
{
    public interface IInfectedUserService
    {
        Task<InfectedUser> AddInfectedUser(InfectedUserDto infectedUser);

        Task<InfectedUser> UpdateInfectedUser(string id, InfectedUserDto infectedUser);

        Task DeleteInfectedUser(string id);

        Task<InfectedUser> GetInfectedUser(string id);

        Task<IEnumerable<InfectedUser>> GetInfectedUsers();
    }
}