using SummerSchoolCovidAPI.Models;
using SummerSchoolCovidAPI.Models.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SummerSchoolCovidAPI.Interfaces
{
   public interface ICovidCaseContactService
    {

        Task<CovidCaseContact> AddCovidCaseContact(CovidCaseContactDto covidCaseContact);
        Task<List<CovidCaseContact>> UpdateCovidCaseContact(string id, CovidCaseContactDto covidCaseContact);
        Task DeleteCovidCaseContact(string id);
        Task<CovidCaseContact> GetCovidCaseContact(string id);
        Task<IEnumerable<CovidCaseContact>> GetCovidCaseContact();
    }
}
