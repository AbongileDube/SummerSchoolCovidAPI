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
        private readonly IInfectedUserService _infectedUserService;

        public InfectedUsersController(IInfectedUserService context)
        {
            _infectedUserService = context;
        }

        // GET: api/InfectedUsers
        [HttpGet]
        public async Task<ActionResult<IEnumerable<InfectedUserDto>>> GetInfectedUsers()
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
        public async Task<ActionResult<InfectedUser>> UpdateInfectedUser(string id, InfectedUserDto infectedUserDTO)
        {
            if (id != infectedUserDTO.Id)
            {
                return BadRequest();
            }

            return Ok(await _infectedUserService.UpdateInfectedUser(id, infectedUserDTO));
        }

        // POST: api/InfectedUsers
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<InfectedUser>> PostInfectedUser(InfectedUserDto infectedUser)
        {
            var addedInfectedUser = await _infectedUserService.AddInfectedUser(infectedUser);
            return CreatedAtAction("/", new { id = infectedUser.Id }, addedInfectedUser);
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

            return NoContent();
        }
    }
}