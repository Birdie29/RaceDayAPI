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
        public void InvalidRegistrationData()
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

        [Fact]
        public void UnauthenticatedUser()
        {
            var registration = new Registration
            {
                registrationID = 5,
                registrationDate = DateTime.Now,
                registrationChannel = "Email",
                registrationStatus = "Alive",
                participantID = 2,
                eventID = 3,
                categoryID = 4
            };

            var result = await _controller.CreateRegistration(registration);
            Assert.IsType<UnauthorizedResult>(result);
    }

    [Fact]
    public void UnauthorizedUser()
    {
        var registration = new Registration
        {
            registrationID = 6,
            registrationDate = DateTime.Now,
            registrationChannel = "Phone",
            registrationStatus = "Pending",
            participantID = 7,
            eventID = 8,
            categoryID = 9
        };

        var result = await _controller.CreateRegistration(registration);
        Assert.IsType<ForbidResult>(result);
}
