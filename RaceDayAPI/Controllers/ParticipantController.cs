using Microosft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using RaceDayAPI.Modelss;

namspace RaceDayAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class
    ParticipantProfileController : ControllerBase
    {
        private readonly
        RaceDayContext _ context;

        public ParticipantProfileController(
            RaceDayContext context
        )
        {
            _context = context;
        }

        [HttpGet("id")]
        public async
        Task<IActionResult>
        GetParticipant(int id)
        {
            var participant = await 
            _context.Participant
            .FirstOrDefaultAsync(p =>
            p.participantID == id);

            if(paticipant == null)
            {
                return NotFound(new
                {
                    message = "Participant not found."
                });
            }
            return Ok(new
            {
                participant.participantID,
                participant.participantName,
                participant.participantSurname,
                participant.email,
                participant.phoneNumber
            });

            [HttpPut("id")]
            public async
            Task<IActionResult> UpdatedParticipant(
                int id, Participant updatedParticipant)
                {
                    var participant = await
                    _context.Participant

                    .FirstOrDefaultAsync(p => p.participantID == id);

                    if(participant == null)
                    {
                        return NotFound(new
                        {
                            message = "Participant not found"
                        });
                    }

                    participant.participantName = updatedParticipant.participantName;
                    participant.participantSurname = updatedParticipant.participantSurname;
                    participant.email = updatedParticipant.email;
                    participant.phoneNumber = updatedParticipant.phoneNumber;
                    await
                    _context.SaveChangesAsync();
                    return Ok(new
                    {
                        message = "Participant profile updated successfully",
                        participant.participantID,
                        participant,participantName,
                        participant.participantSurname, participant.email,
                        participant.phoneNumber
                    });
                }
        }
    }
}