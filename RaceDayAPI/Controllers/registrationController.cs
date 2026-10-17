using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using RaceDayAPI.Data;
using RaceDayAPI.Modelss;

namespace RaceDayAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class RegistrationController : ControllerBase
    {
        private readonly RaceDayContext _context;

        public RegistrationController(RaceDayContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<IActionResult> GetRegistrations()
        {
            var registrations = await _context.Registrations.ToListAsync();
            return Ok(registrations);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetRegistration(int id)
        {
            var registration = await _context.Registrations.FindAsync(id);

            if (registration == null)
            {
                return NotFound();
            }

            return Ok(registration);
        }

        [HttpPost]
        public async Task<IActionResult> CreateRegistration(registration newRegistration)
        {
            _context.Registrations.Add(newRegistration);
            await _context.SaveChangesAsync();

            return CreatedAtAction(
                nameof(GetRegistration),
                new { id = newRegistration.registrationID },
                newRegistration);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateRegistration(int id, registration updatedRegistration)
        {
            if (id != updatedRegistration.registrationID)
            {
                return BadRequest("Registration ID does not match.");
            }

            var registration = await _context.Registrations.FindAsync(id);

            if (registration == null)
            {
                return NotFound();
            }

            registration.registrationDate = updatedRegistration.registrationDate;
            registration.registrationChannel = updatedRegistration.registrationChannel;
            registration.participantID = updatedRegistration.participantID;
            registration.eventID = updatedRegistration.eventID;
            registration.categoryID = updatedRegistration.categoryID;

            await _context.SaveChangesAsync();
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteRegistration(int id)
        {
            var registration = await _context.Registrations.FindAsync(id);

            if (registration == null)
            {
                return NotFound();
            }

            _context.Registrations.Remove(registration);
            await _context.SaveChangesAsync();

            return NoContent();
        }
    }
}