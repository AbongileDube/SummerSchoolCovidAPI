using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SummerSchoolCovidAPI.Models;

namespace SummerSchoolCovidAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CovidCasesController : ControllerBase
    {
        private readonly CovidAPIContext _context;

        public CovidCasesController(CovidAPIContext context)
        {
            _context = context;
        }

        // GET: api/CovidCases
        [HttpGet]
        public async Task<ActionResult<IEnumerable<CovidCase>>> GetCovidCases()
        {
            return await _context.CovidCases.ToListAsync();
        }

        // GET: api/CovidCases/5
        [HttpGet("{id}")]
        public async Task<ActionResult<CovidCase>> GetCovidCase(string id)
        {
            var covidCase = await _context.CovidCases.FindAsync(id);

            if (covidCase == null)
            {
                return NotFound();
            }

            return covidCase;
        }

        // PUT: api/CovidCases/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutCovidCase(string id, CovidCase covidCase)
        {
            if (id != covidCase.Id)
            {
                return BadRequest();
            }

            _context.Entry(covidCase).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!CovidCaseExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        // POST: api/CovidCases
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<CovidCase>> PostCovidCase(CovidCase covidCase)
        {
            _context.CovidCases.Add(covidCase);
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (CovidCaseExists(covidCase.Id))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtAction("GetCovidCase", new { id = covidCase.Id }, covidCase);
        }

        // DELETE: api/CovidCases/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteCovidCase(string id)
        {
            var covidCase = await _context.CovidCases.FindAsync(id);
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
