using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using RaceDayAPI.Data;
using RaceDayAPI.Modelss;

namespace RaceDayAPI.Controllers
{
    [Authorize(Roles = "Participant")]
    [ApiController]
    [Route("api/[controller]")]
    public class ParticipantController : ControllerBase
    {
        private readonly RaceDayContext _context;
        private readonly IPasswordHasher<Participant> _passwordHasher;

        public ParticipantController(
            RaceDayContext context,
            IPasswordHasher<Participant> passwordHasher)
        {
            _context = context;
            _passwordHasher = passwordHasher;
        }

        [AllowAnonymous]
        [HttpPost("register")]
        public async Task<IActionResult> RegisterParticipant(RegisterParticipantRequest request)
        {
            var email = request.email.Trim();
            if (await _context.Participants.AnyAsync(participant => participant.email == email))
            {
                return Conflict(new { message = "A participant with this email already exists." });
            }

            var participant = new Participant
            {
                participantName = request.participantName,
                participantSurname = request.participantSurname,
                email = email,
                phoneNumber = request.phoneNumber
            };
            participant.passwordHash = _passwordHasher.HashPassword(participant, request.password);

            _context.Participants.Add(participant);
            await _context.SaveChangesAsync();

            return CreatedAtAction(nameof(GetParticipant), new { id = participant.participantID }, new
            {
                participant.participantID,
                participant.participantName,
                participant.participantSurname,
                participant.email,
                participant.phoneNumber
            });
        }

        [HttpGet]
        [Authorize(Roles = "Participant")]
        public async Task<IActionResult> GetParticipants()
        {
            var participants = await _context.Participants
                .Select(participant => new
                {
                    participant.participantID,
                    participant.participantName,
                    participant.participantSurname,
                    participant.email,
                    participant.phoneNumber
                })
                .ToListAsync();

            return Ok(participants);
        }

        [HttpGet("{id:int}")]
        [Authorize(Roles = "Participant")]
        public async Task<IActionResult> GetParticipant(int id)
        {
            var participant = await _context.Participants
                .FirstOrDefaultAsync(participant => participant.participantID == id);

            if (participant == null)
            {
                return NotFound();
            }

            return Ok(new
            {
                participant.participantID,
                participant.participantName,
                participant.participantSurname,
                participant.email,
                participant.phoneNumber
            });
        }

        [HttpPost]
        [Authorize(Roles = "Participant")]
        public async Task<IActionResult> CreateParticipant(Participant participant)
        {
            _context.Participants.Add(participant);
            await _context.SaveChangesAsync();

            return CreatedAtAction(nameof(GetParticipant), new { id = participant.participantID }, new
            {
                participant.participantID,
                participant.participantName,
                participant.participantSurname,
                participant.email,
                participant.phoneNumber
            });
        }

        [HttpPut("{id:int}")]
        [Authorize(Roles = "Participant")]
        public async Task<IActionResult> UpdateParticipant(int id, Participant updatedParticipant)
        {
            var participant = await _context.Participants
                .FirstOrDefaultAsync(participant => participant.participantID == id);

            if (participant == null)
            {
                return NotFound();
            }

            participant.participantName = updatedParticipant.participantName;
            participant.participantSurname = updatedParticipant.participantSurname;
            participant.email = updatedParticipant.email;
            participant.phoneNumber = updatedParticipant.phoneNumber;
            participant.passwordHash = updatedParticipant.passwordHash;

            await _context.SaveChangesAsync();

            return Ok(new
            {
                participant.participantID,
                participant.participantName,
                participant.participantSurname,
                participant.email,
                participant.phoneNumber
            });
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteParticipant(int id)
        {
            var participant = await _context.Participants
                .FirstOrDefaultAsync(participant => participant.participantID == id);

            if (participant == null)
            {
                return NotFound();
            }

            _context.Participants.Remove(participant);
            await _context.SaveChangesAsync();

            return NoContent();
        }
    }
}