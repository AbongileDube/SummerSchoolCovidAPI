using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using SummerSchoolCovidAPI.Models;
using SummerSchoolCovidAPI.Models.DTO;

namespace SummerSchoolCovidAPI.Interfaces
{
    public interface ILocationService
    {
        Task<Location> AddLocation(LocationDTO location);
        Task<Location> UpdateLocation(string id, LocationDTO location);
        Task DeleteLocation(string id);
        Task<Location> GetLocation(string id);
        Task<IEnumerable<Location>> GetLocations();
    }
}
