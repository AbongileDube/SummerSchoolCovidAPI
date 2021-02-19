using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SummerSchoolCovidAPI.Interfaces;
using SummerSchoolCovidAPI.Models;
using SummerSchoolCovidAPI.Models.DTO;

namespace SummerSchoolCovidAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CovidCasesController : ControllerBase
    {
        private readonly ICovidCaseService _covidCaseService;
        private readonly IInfectedUserService _infectedUserService;
        private readonly ILocationService _locationService;

        public CovidCasesController(ICovidCaseService covidCaseService, IInfectedUserService infectedUserService, ILocationService locationService)
        {
            _covidCaseService = covidCaseService;
            _infectedUserService = infectedUserService;
            _locationService = locationService;
        }

        // GET: api/CovidCases
        [HttpGet]
        public async Task<ActionResult<IEnumerable<CovidCase>>> GetCovidCases()
        {
            return Ok(await _covidCaseService.GetCovidCases());
        }

        // GET: api/CovidCases/5
        [HttpGet("{id}")]
        public async Task<ActionResult<CovidCase>> GetCovidCase(string id)
        {
            var covidCase = await _covidCaseService.GetCovidCase(id);

            if (covidCase == null)
            {
                return NotFound();
            }

            return Ok(covidCase);
        }

        // PUT: api/CovidCases/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutCovidCase(string id, CovidCaseDto covidCase)
        {
            if (id != covidCase.Id)
            {
                return BadRequest();
            }

            var covidcase = await _covidCaseService.UpdateCovidCase(id, covidCase);

            return Ok(covidcase);
        }

        // POST: api/CovidCases
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<CovidCase>> PostCovidCase(CovidCaseDto covidCase)
        {
            var infectedUser = await _infectedUserService.GetInfectedUser(covidCase.InfectedUserId);
            var location = await _locationService.GetLocation(infectedUser.LocationId);
            await _locationService.UpdateLocation(location.Id, new LocationDto
            {
                Id = location.Id,
                City = location.City,
                Suburb = location.Suburb,
                Province = location.Province,
                CNumberInfected = location.CNumberInfected + 1,
            }
            );
            var covidCaseResult = await _covidCaseService.AddCovidCase(covidCase);

            return Ok(covidCaseResult);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteCovidCase(string id)
        {
            var covidCase = await _covidCaseService.GetCovidCase(id);
            if (covidCase == null)
            {
                return NotFound();
            }

            await _covidCaseService.DeleteCovidCase(id);
            return NoContent();
        }
    }
}