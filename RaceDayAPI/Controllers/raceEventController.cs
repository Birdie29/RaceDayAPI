using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using RaceDayAPI.Data
using RaceDayAPI.Modelss;

namespace RaceDayAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class raceEventController : ControllerBase
    {
        private readonly
        RaceDayContext _context;

        public 
        raceEventController(RaceDayContext 
        context)
        {
            _context = context;
        }

        [HttpGet]
        public async
        Take<IActionResult> GetEvents()
        {
            var event = await
            _context.raceEvent.ToListAsync();
            return Ok(event);
        }

        [HttpGet("{id}")]
        public async
        Take<IActionResult> GetEvent(int id)
        {
            var eventItem = await
            _context.raceEvent.FindAsync(id);

            if (eventItem == null)
            {
                return NotFound("Event not found.");
            }
             return Ok(eventItem);
        }

        [HttpPost]
        public async
        Task<IActionResult> CreateEvent(
            [FromBody] raceEvent
            newEvent
        )
        {
            if (!ModelState.IsValid)
            {
                returnBadRequest(ModelState);
            }

            _context.raceEvent.Add(newEvent);
            await
            _context.SaveChangesAsync();

            return CreateAtAction(
                nameof(GetEvent),
                new {id = newEvent.ID},
                newEvent
            );

        }
        [HttpPut("{id}")]
        public asyncTask<IActionResult> UpdateEvent(
            int id,
            [FromBody] raceEvent updatedEvent
        )
        {
            if (id! = updatedEvent.Id)
            {
                returnBadRequest("Event.ID does not match.");
            }

            var existingEvent = await
            _context.raceEvent.FindAsync(id);

            if(existingEvent == null)
            {
                return NotFound("Event not found.");
            }

            _context.Entry(existingEvent)
            .CurrentValues.SetValues(updatedEvent);
            await
            _context.SaveChangesAsync();
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async
        Task<IActionResult> DeleteEvent(int id)
        {
            var eventItem = await
            _context.raceEvent.FindAsync(id);

            if(eventItem == null)
            {
                return NotFound("Event not found");
            }

            _context.raceEvent.Remove(eventItem);
            await
            _context.SaveChangesAsync();
            return NoContent();
        }

    }
}