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
    public class InfectedUsersController : ControllerBase
    {
        private readonly CovidAPIContext _context;
        private readonly IInfectedUserService _infectedUserService;

        public InfectedUsersController(IInfectedUserService infectedUserService)
        {
            _infectedUserService = infectedUserService;
        }

        // GET: api/InfectedUsers
        [HttpGet]
        public async Task<ActionResult<IEnumerable<InfectedUserDTO>>> GetInfectedUsers()
        {
            return Ok(await _infectedUserService.GetInfectedUsers());
        }

        // GET: api/InfectedUsers/5
        [HttpGet("{id}")]
        public async Task<ActionResult<InfectedUser>> GetInfectedUser(string id)
        {
            var infectedUser = await _infectedUserService.GetInfectedUser(id);

            if (infectedUser == null)
            {
                return NotFound();
            }

            return infectedUser;
        }

        // PUT: api/InfectedUsers/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateInfectedUser(string id, InfectedUserDTO infectedUserDTO)
        {
            if (id != infectedUserDTO.Id)
            {
                return BadRequest();
            }

            try
            {
                await _infectedUserService.UpdateInfectedUser(id, infectedUserDTO);
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!InfectedUserExists(id))
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

        // POST: api/InfectedUsers
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<InfectedUser>> PostInfectedUser(InfectedUserDTO infectedUser)
        {
            
            try
            {
                await _infectedUserService.AddInfectedUser(infectedUser);
            }
            catch (DbUpdateException)
            {
                if (InfectedUserExists(infectedUser.Id))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtAction("GetInfectedUser", new { id = infectedUser.Id }, infectedUser);
        }

        // DELETE: api/InfectedUsers/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteInfectedUser(string id)
        {
            var infectedUser = await _infectedUserService.GetInfectedUser(id);
            if (infectedUser == null)
            {
                return NotFound();
            }

            await _infectedUserService.DeleteInfectedUser(id);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool InfectedUserExists(string id)
        {
            return _context.InfectedUsers.Any(e => e.Id == id);
        }
    }
}
