using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Security.Claims;
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
        private readonly IPasswordHasher<Organiser> _passwordHasher;

        public OrganiserController(
            RaceDayContext context,
            IPasswordHasher<Organiser> passwordHasher)
        {
            _context = context;
            _passwordHasher = passwordHasher;
        }

        [AllowAnonymous]
        [HttpPost("register")]
        public async Task<IActionResult> RegisterOrganiser(RegisterOrganiserRequest request)
        {
            var email = request.email.Trim();
            if (await _context.Organisers.AnyAsync(organiser => organiser.email == email))
            {
                return Conflict(new { message = "An organiser with this email already exists." });
            }

            var organiser = new Organiser
            {
                organiserName = request.organiserName,
                organiserSurname = request.organiserSurname,
                email = email,
                phoneNumber = request.phoneNumber
            };
            organiser.passwordHash = _passwordHasher.HashPassword(organiser, request.password);

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

      [HttpPost("login")]
      [AllowAnonymous]
        public async Task<IActionResult> LoginOrganiser(LoginRequest request)
        {
           var organiser = await _context.Organisers
                .FirstOrDefaultAsync(o => o.email == request.email);

            if (organiser == null)
            {
                return Unauthorized(new { message = "Invalid email or password." });
            }

            var passwordVerificationResult = _passwordHasher.VerifyHashedPassword(organiser, organiser.passwordHash, request.password);
            if (passwordVerificationResult != PasswordVerificationResult.Success)
            {
                return Unauthorized(new { message = "Invalid email or password." });
            }

            var claims = new List<Claim>
            {
                new Claim(ClaimTypes.NameIdentifier, organiser.organiserID.ToString()),
                new Claim(ClaimTypes.Name, organiser.organiserName),
                new Claim(ClaimTypes.Role, "Organiser")
            };

            var claimsIdentity = new ClaimsIdentity(claims, CookieAuthenticationDefaults.AuthenticationScheme);
            var authProperties = new AuthenticationProperties
            {
                IsPersistent = true,
                ExpiresUtc = DateTimeOffset.UtcNow.AddHours(1)
            };

            await HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme, new ClaimsPrincipal(claimsIdentity), authProperties);

            return Ok(new { message = "Login successful." });
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
        [Authorize(Roles = "Participant, Organiser")]
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