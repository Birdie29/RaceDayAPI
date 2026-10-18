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
                registrationID = 1,
                registrationDate = DateTime.Now, 
                registrationChannel = "Online",
                registrationStatus = "Confirmed",
                participantID = 1,
                eventID = 1,
                categoryID = 1

            };

            var result = controller.CreateRegistration(registration);

            Assert.IsType<CreatedActionResult>(result);
        }

        [Fact]
        public void ParticipantFailureRegistration()
        {
            var registration = new Registration
            {
                registrationID = 1,
                registrationDate = DateTime.Now,
                registrationChannel = "Online",
                registrationStatus = "Confirmed",
                participantID = 1,
                eventID = 1,
                categoryID = 1
            };

            var context = new ValidationContext(registration);
            var validationResults = new List<ValidationResult>();
            bool isValid = Validator.TryValidateObject(registration, context, validationResults, true);
            Assert.False(isValid);
            Assert.NotEmpty(validationResults);
        }
    }
}