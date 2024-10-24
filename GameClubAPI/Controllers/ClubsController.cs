using GameClubAPI.Models;
using GameClubAPI.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Data.Sqlite;
using Microsoft.EntityFrameworkCore;

namespace GameClubAPI.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class ClubsController : ControllerBase
    {
        private IClubService clubService;
        public ClubsController(IClubService clubService)
        {
            this.clubService = clubService;
        }

        [HttpPost]
        public async Task<IActionResult> Post([FromBody] Club club)
        {
            if (ModelState.IsValid)
            {
                if (await clubService.GetClubByName(club.Name) != null)
                    return Conflict("Club with the same name already exists.");
                await clubService.CreateClub(club);
                return Created("Name", club.Name);
            }

            return BadRequest(ModelState);
        }

        [HttpGet]
        public async Task<ActionResult<List<Club>>> SearchClubs([FromQuery] string? searchText)
        {
            return await clubService.SearchClubs(searchText);

        }

        [HttpPost("clubs/{id}/events")]
        public async Task<IActionResult> CreateEvent(int id, [FromBody] Event newEvent)
        {

            if (await clubService.GetClubById(id) == null)
            {
                return NotFound("Club not found");
            }
            newEvent.ClubId = id;
            await clubService.CreateEvent(newEvent);
            return Created("New Event", newEvent.Title);
        }

        [HttpGet("clubs/{id}/events")]
        public async Task<ActionResult<IEnumerable<Event>>> GetEventsForClub(int id)
        {
            var result = await clubService.GetEventsForClub(id);
            return Ok(result);
        }

    }
}
