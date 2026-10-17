using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameowkCore;
using RaceDayAPI.Modelss;

namespace RaceDay.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class registration : ControllerBase
    {
        private readonly
        RaceDayContext _context;

        public
        registration(RaceDayContext context)
        {
            _context = context;
        }

        [HttpPost("Participant")]
        public async
        Task<IActionResult>
        registerParticipant(Participant participant)
        {
            var email = participant.Email.Trim().ToLowerInvariant();

            bool emailExists = await
            _context.Participant
            .AnyAsync(p =>
            p.Email == email)
             || await
             _context.Organiser.AnyAsync(
                o => o.Email == email
             );

             if(emailExists)
             {
                return Conflict(new
                {
                    message = "This email is already registered."
                });
             }
                participant.Email = email;
                participant.Password = BCrypt.Net.BCrypt.HashPassword(participant.Password);

                _context.Participants.Add(participant);
                await
                _context.SaveChangesAsync();

                return
                Created("/api/registration/Participant", new
                {
                    message = "Participant registered successfully.",
                    participantID = participant.ParticipantID,
                    name = participant.ParticipantName,
                    email =participant.ParticipantEmail
                });

                [HttpPost("Organiser")]
                public async
                Task<IActionResult>RegisterOrganiser(
                    Organiser organiser)
               {
                    var email =
                    organiser.Email.Trim().ToLowerInvariant();

                    bool emailExists = await
                    _context.Organiser.AnyAsync(
                        o => o.Email ==
                        email
                    )
                    || await
                    _context.Participant.AnyAsync(
                        p => p.Email == email
                    );

                    if(emailExists
                    {
                        return Conflict(new
                        {
                            message = "This email is already registered."
                        });
                    }
                    organiser.Email = email;
                    organiser.Password = BCrypt.Net.BCrypt.HashPassword(
                        organiser.Password
                    );

                    _context.Organiser.Add(organiser);
                    await
                    _context.SaveChangesAsync();

                    return 
                    Created("/api/registration/Organiser", new
                    {
                        message = "Organiser registered successfully.",
                        organiserID = organiser.OrganiserID,
                        name = organiser.OrganiserName,
                        email = organiser.OrganiserEmail
                    });
                    
               } 
        }

     
    }
}