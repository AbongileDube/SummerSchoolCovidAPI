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

        public CovidCaseContactsController(ICovidCaseContactService covidcontactservice)
        {
            _covidCaseContactService = covidcontactservice;
        }

        // GET: api/CovidCaseContacts
        [HttpGet]
        public async Task<ActionResult<IEnumerable<CovidCaseContactDto>>> GetContact()
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
        public async Task<IActionResult> UpdateCovidCaseContact(string id, CovidCaseContactDto covidCaseContactDTO)
        {
            if (id != covidCaseContactDTO.Id)
            {
                return BadRequest();
            }

            return Ok(await _covidCaseContactService.UpdateCovidCaseContact(id, covidCaseContactDTO));
        }

        // POST: api/CovidCaseContacts
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<CovidCaseContact>> PostCovidCaseContact(CovidCaseContactDto covidCaseContact)
        {
            var addedCovidCaseContact = await _covidCaseContactService.AddCovidCaseContact(covidCaseContact);
            return CreatedAtAction("/", new { id = covidCaseContact.Id }, addedCovidCaseContact);
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
    }
}