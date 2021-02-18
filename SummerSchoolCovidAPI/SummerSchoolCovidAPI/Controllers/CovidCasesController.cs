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
using SummerSchoolCovidAPI.Models.Logic;

namespace SummerSchoolCovidAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CovidCasesController : ControllerBase
    {
        private readonly ICovidCaseService _covidCaseService;
        private readonly IInfectedUserService _infectedUserService;
        private readonly CovidAPIContext _context;

        public CovidCasesController(ICovidCaseService covidCaseService, IInfectedUserService infectedUserService)
        {
            _covidCaseService = covidCaseService;
            _infectedUserService = infectedUserService;
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
        public async Task<IActionResult> PutCovidCase(string id, CovidCaseDTO covidCase)
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
        public async Task<ActionResult<CovidCase>> PostCovidCase(CovidCaseDTO covidCase)
        {
            //var infectedUser = await _infectedUserService.GetInfectedUser(covidCase.Id);
            if (covidCase.Infected == true)
            {
                Logic.updateInfectedUser(covidCase.InfectedUserId);
                Logic.updateLocation(covidCase.InfectedUserId);
            }

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

            _context.CovidCases.Remove(covidCase);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool CovidCaseExists(string id)
        {
            return _context.CovidCases.Any(e => e.Id == id);
        }
    }
}
