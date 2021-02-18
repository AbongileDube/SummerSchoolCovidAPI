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
using SummerSchoolCovidAPI.Services;

namespace SummerSchoolCovidAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CovidCaseContactsController : ControllerBase
    {

        private readonly ICovidCaseContactService _covidCaseContactService;
        private readonly CovidAPIContext _context;


        public CovidCaseContactsController(ICovidCaseContactService covidcontactservice)
        {
            _covidCaseContactService = covidcontactservice;
        }

        // GET: api/CovidCaseContacts
        [HttpGet]
        public async Task<ActionResult<IEnumerable<CovidCaseContactDTO>>> GetContact()
        {
            return Ok(await _covidCaseContactService.GetCovidCaseContact());

        }
        // GET: api/CovidCaseContacts/5
        [HttpGet("{id}")]
        public async Task<ActionResult<CovidCaseContact>> GetCovidCaseContact(string id)
        {
            var covidCaseContact = await _covidCaseContactService.GetCovidCaseContact(id);

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
                await _covidCaseContactService.UpdateCovidCaseContact(id, covidCaseContactDTO);
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
        public async Task<ActionResult<CovidCaseContact>> PostCovidCaseContact(CovidCaseContactDTO covidCaseContact)
        {
           
            
                await _covidCaseContactService.AddCovidCaseContact(covidCaseContact);

            return CreatedAtAction(nameof(GetCovidCaseContact), new { id = covidCaseContact.Id }, covidCaseContact);
        }

        // DELETE: api/CovidCaseContacts/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteCovidCaseContact(string id)
        {
            var covidCaseContact = await _covidCaseContactService.GetCovidCaseContact(id);
            if (covidCaseContact == null)
            {
                return NotFound();
            }

            await _covidCaseContactService.DeleteCovidCaseContact(id);

            return NoContent();
        }

        private bool CovidCaseContactExists(string id)
        {
            return _context.CovidCaseContacts.Any(e => e.Id == id);
        }
    }
}
