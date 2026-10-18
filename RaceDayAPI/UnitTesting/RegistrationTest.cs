using Xunit;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace RaceDayAPI.UnitTesting
{
    public class RegistrationTest
    {
        [Fact]
        public void RegisteredParticipant()
        {
            var registration = new Registration
            {
                registrationID = 501,
                registrationDate = DateTime.Now, 
                registrationChannel = "Online",
                registrationStatus = "Winner",
                participantID = 202,
                eventID = 301,
                categoryID = 401

            };

            var result = await _controller.CreateRegistration(registration);

            Assert.IsType<OkObjectResult>(result);
        }
        [Fact]
        public void InvalidParticipantRegistration()
        {
            var registration = new Registration
            {
                registrationID = 502,
                registrationDate = DateTime.Now,    
            registrationChannel = "Disconnected",
                registrationStatus = "DNF",
                participantID = 202,
                eventID = null,
                categoryID = 402
            };

            _controller.ModelState.AddModelError("eventID", "The eventID field is required.");

            var result = await _controller.CreateRegistration(registration);
            Assert.IsType<BadRequestObjectResult>(result);
        }

    }
}