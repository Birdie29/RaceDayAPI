using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using RaceDayAPI.Data;
using RaceDayAPI.Modelss;

namespace RaceDayAPI.Controllers
{
    [Authorize(Roles = "Organiser")]
    [ApiController]
    [Route("api/[controller]")]
    public class OrganiserController : ControllerBase
    {
        private readonly RaceDayContext _context;

        public OrganiserController(RaceDayContext context)
        {
            _context = context;
        }

        [HttpGet]
        [Authorize(Roles = "Organiser")]
        public async Task<IActionResult> GetOrganisers()
        {
            var organisers = await _context.Organisers
                .Select(organiser => new
                {
                    organiser.organiserID,
                    organiser.organiserName,
                    organiser.organiserSurname,
                    organiser.email,
                    organiser.phoneNumber
                })
                .ToListAsync();

            return Ok(organisers);
        }

        [HttpGet("{id:int}")]
        [Authorize(Roles = "Participant")]
        public async Task<IActionResult> GetOrganiser(int id)
        {
            var organiser = await _context.Organisers
                .FirstOrDefaultAsync(organiser => organiser.organiserID == id);

            if (organiser == null)
            {
                return NotFound();
            }

            return Ok(new
            {
                organiser.organiserID,
                organiser.organiserName,
                organiser.organiserSurname,
                organiser.email,
                organiser.phoneNumber
            });
        }

        [HttpPost]
        [Authorize(Roles = "Organiser")]
        public async Task<IActionResult> CreateOrganiser(Organiser organiser)
        {
            _context.Organisers.Add(organiser);
            await _context.SaveChangesAsync();

            return CreatedAtAction(nameof(GetOrganiser), new { id = organiser.organiserID }, new
            {
                organiser.organiserID,
                organiser.organiserName,
                organiser.organiserSurname,
                organiser.email,
                organiser.phoneNumber
            });
        }

        [HttpPut("{id:int}")]
        [Authorize(Roles = "Organiser")]
        public async Task<IActionResult> UpdateOrganiser(int id, Organiser updatedOrganiser)
        {
            var organiser = await _context.Organisers
                .FirstOrDefaultAsync(organiser => organiser.organiserID == id);

            if (organiser == null)
            {
                return NotFound();
            }

            organiser.organiserName = updatedOrganiser.organiserName;
            organiser.organiserSurname = updatedOrganiser.organiserSurname;
            organiser.email = updatedOrganiser.email;
            organiser.phoneNumber = updatedOrganiser.phoneNumber;
            organiser.passwordHash = updatedOrganiser.passwordHash;

            await _context.SaveChangesAsync();

            return Ok(new
            {
                organiser.organiserID,
                organiser.organiserName,
                organiser.organiserSurname,
                organiser.email,
                organiser.phoneNumber
            });
        }

        [HttpDelete("{id:int}")]
        [Authorize(Roles = "Organiser")]
        public async Task<IActionResult> DeleteOrganiser(int id)
        {
            var organiser = await _context.Organisers
                .FirstOrDefaultAsync(organiser => organiser.organiserID == id);

            if (organiser == null)
            {
                return NotFound();
            }

            _context.Organisers.Remove(organiser);
            await _context.SaveChangesAsync();

            return NoContent();
        }
    }
}