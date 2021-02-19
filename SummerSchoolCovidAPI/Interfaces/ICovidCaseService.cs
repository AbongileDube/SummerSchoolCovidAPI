using SummerSchoolCovidAPI.Models;
using SummerSchoolCovidAPI.Models.DTO;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SummerSchoolCovidAPI.Interfaces
{
   public interface ICovidCaseService
    {
        Task<CovidCase> AddCovidCase(CovidCaseDto covidCase);
        Task<CovidCase> UpdateCovidCase( string id, CovidCaseDto covidCase);
        Task DeleteCovidCase(string id);
        Task<CovidCase> GetCovidCase(string id);
        Task<IEnumerable<CovidCase>> GetCovidCases();

    }
}
