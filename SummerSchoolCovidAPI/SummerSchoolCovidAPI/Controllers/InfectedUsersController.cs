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
    public class InfectedUsersController : ControllerBase
    {
        private readonly CovidAPIContext _context;

        public InfectedUsersController(CovidAPIContext context)
        {
            _context = context;
        }

        // GET: api/InfectedUsers
        [HttpGet]
        public async Task<ActionResult<IEnumerable<InfectedUser>>> GetInfectedUsers()
        {
            return await _context.InfectedUsers.ToListAsync();
        }

        // GET: api/InfectedUsers/5
        [HttpGet("{id}")]
        public async Task<ActionResult<InfectedUser>> GetInfectedUser(string id)
        {
            var infectedUser = await _context.InfectedUsers.FindAsync(id);

            if (infectedUser == null)
            {
                return NotFound();
            }

            return infectedUser;
        }

        // PUT: api/InfectedUsers/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutInfectedUser(string id, InfectedUser infectedUser)
        {
            if (id != infectedUser.Id)
            {
                return BadRequest();
            }

            _context.Entry(infectedUser).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
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
        public async Task<ActionResult<InfectedUser>> PostInfectedUser(InfectedUser infectedUser)
        {
            _context.InfectedUsers.Add(infectedUser);
            try
            {
                await _context.SaveChangesAsync();
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
            var infectedUser = await _context.InfectedUsers.FindAsync(id);
            if (infectedUser == null)
            {
                return NotFound();
            }

            _context.InfectedUsers.Remove(infectedUser);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool InfectedUserExists(string id)
        {
            return _context.InfectedUsers.Any(e => e.Id == id);
        }
    }
}
