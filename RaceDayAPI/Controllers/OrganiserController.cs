using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using RaceDayAPI.Modelss;

namespace RaceDayAPI.Controllers
{
    [ApiController]
    [Route("api/[Controller]")]
    public class OrganiserController : ControllerBase
    {
        private readonly RaceDayContext _ context;

        public OrganiserProfileController(RaceDayContext context)
        {
            _context = context;
        }

        [HttpGet({{"id"}})]
        public async
        Task<IActionResult> GetOrganiser(int id)
        {
            var organiser = await _ context.Organisers
            .FirstOrDefaultAsync(o =>
            o.organiserID == id);

            if(organiser == null)
            {
                return NotFound(new
                {
                    message = "Organiser not found"
                });
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
        [HttpPut("{id}")]
        public async
        Task<IActionResult> UpdateOrganiser(
            int id, Organiser
            updatedOrganiser
        )
        {
            var organiser = await
            _context.Organisers
            .FirstOrDefaultAsync(o =>
            o.organiserID = id);

            if(organiser == null)
            {
                return NotFound(new
                {
                    message = "Organiser not found"
                });
            }
            organiser.organiserName = updatedOrganiser.organiserName;
            organiser.organiserSurname = updatedOrganiser.organiserSurname;
            organiser.email = updatedOrganiser.email;
            organiser.phoneNumber = updatedOrganiser.phoneNumber;
            await
            _context.SaveChangesAsync();
            return Ok(new
            {
                message = "Organiser profile updated successfully",
                organiser.organiserID,
                organiser.organiserName,
                organiser.organiserSurname,
                organiser.email,
                organiser.phoneNumber
            });
        }
    }
}