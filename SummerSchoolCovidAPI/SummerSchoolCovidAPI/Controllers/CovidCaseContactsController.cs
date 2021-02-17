using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SummerSchoolCovidAPI.Models;
using SummerSchoolCovidAPI.Models.DTO;

namespace SummerSchoolCovidAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CovidCaseContactsController : ControllerBase
    {
        private readonly CovidAPIContext _context;

        public CovidCaseContactsController(CovidAPIContext context)
        {
            _context = context;
        }

        // GET: api/CovidCaseContacts
        [HttpGet]
        public async Task<ActionResult<IEnumerable<CovidCaseContactDTO>>> GetContact()
        {
            return Ok(await _context.CovidCaseContacts.ToListAsync());

        }
        // GET: api/CovidCaseContacts/5
        [HttpGet("{id}")]
        public async Task<ActionResult<CovidCaseContact>> GetCovidCaseContact(string id)
        {
            var covidCaseContact = await _context.CovidCaseContacts.FindAsync(id);

            if (covidCaseContact == null)
            {
                return NotFound();
            }

            return covidCaseContact;
        }

        // PUT: api/CovidCaseContacts/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateCovidCaseContact(string id, CovidCaseContactDTO covidCaseContactDTO)
        {
            if (id != covidCaseContactDTO.Id)
            {
                return BadRequest();
            }

            

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!CovidCaseContactExists(id))
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

        // POST: api/CovidCaseContacts
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<CovidCaseContact>> PostCovidCaseContact(CovidCaseContact covidCaseContact)
        {
            _context.CovidCaseContacts.Add(covidCaseContact);
            
                await _context.SaveChangesAsync();

            return CreatedAtAction(nameof(GetCovidCaseContact), new { id = covidCaseContact.Id }, covidCaseContact);
        }

        // DELETE: api/CovidCaseContacts/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteCovidCaseContact(string id)
        {
            var covidCaseContact = await _context.CovidCaseContacts.FindAsync(id);
            if (covidCaseContact == null)
            {
                return NotFound();
            }

            _context.CovidCaseContacts.Remove(covidCaseContact);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool CovidCaseContactExists(string id)
        {
            return _context.CovidCaseContacts.Any(e => e.Id == id);
        }
    }
}
