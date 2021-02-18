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
    public class LocationsController : ControllerBase
    {
         private readonly ILocationService _locationService;

        public LocationsController(ILocationService locationService)
        {
            _locationService = locationService;
        }

        // GET: api/Locations
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Location>>> GetLocations()
        {
            try
            {
                return Ok(await _locationService.GetLocations());

            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        // GET: api/Locations/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Location>> GetLocation(string id)
        {
            var location = await _locationService.GetLocation(id);

            if (location == null)
            {
                return NotFound();
            }

            return Ok(location);
        }

        // PUT: api/Locations/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutLocation(string id, LocationDTO location)
        {
            if (id != location.Id)
            {
                return BadRequest();
            }


            var locations = await _locationService.UpdateLocation(id,location);

            return Ok(locations);

        }

        // POST: api/Locations
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Location>> PostLocation(LocationDTO location)
        {

            var locationResult = await _locationService.AddLocation(location);

            return Ok(locationResult);
            
        }

        // DELETE: api/Locations/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteLocation(string id)
        {

            try
            {
                var location = await _locationService.GetLocation(id);
                if (location == null)
                {
                    return NotFound("Record was not found");
                }

                _locationService.DeleteLocation(id);
                return Ok("Record Successfully Deleted");
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }



           
            return NoContent();
        }

     
    }
}
