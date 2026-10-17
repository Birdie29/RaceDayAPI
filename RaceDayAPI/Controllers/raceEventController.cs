using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using RaceDayAPI.Data;
using RaceDayAPI.Modelss;

namespace RaceDayAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class RaceEventController : ControllerBase
    {
        private readonly RaceDayContext _context;

        public RaceEventController(RaceDayContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<IActionResult> GetEvents()
        {
            var events = await _context.RaceEvents.ToListAsync();
            return Ok(events);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetEvent(int id)
        {
            var raceEvent = await _context.RaceEvents.FindAsync(id);

            if (raceEvent == null)
            {
                return NotFound("Event not found.");
            }

            return Ok(raceEvent);
        }

        [HttpPost]
        public async Task<IActionResult> CreateEvent([FromBody] raceEvent newEvent)
        {
            _context.RaceEvents.Add(newEvent);
            await _context.SaveChangesAsync();

            return CreatedAtAction(
                nameof(GetEvent),
                new { id = newEvent.eventID },
                newEvent);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateEvent(int id, [FromBody] raceEvent updatedEvent)
        {
            if (id != updatedEvent.eventID)
            {
                return BadRequest("Event ID does not match.");
            }

            var existingEvent = await _context.RaceEvents.FindAsync(id);

            if (existingEvent == null)
            {
                return NotFound("Event not found.");
            }

            _context.Entry(existingEvent).CurrentValues.SetValues(updatedEvent);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteEvent(int id)
        {
            var raceEvent = await _context.RaceEvents.FindAsync(id);

            if (raceEvent == null)
            {
                return NotFound("Event not found.");
            }

            _context.RaceEvents.Remove(raceEvent);
            await _context.SaveChangesAsync();

            return NoContent();
        }
    }
}