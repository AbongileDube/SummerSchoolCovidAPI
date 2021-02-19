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
        Task<Location> AddLocation(LocationDto location);
        Task<Location> UpdateLocation(string id, LocationDto location);
        Task DeleteLocation(string id);
        Task<Location> GetLocation(string id);
        Task<IEnumerable<Location>> GetLocations();
        bool Exists(Location location);
    }
}
