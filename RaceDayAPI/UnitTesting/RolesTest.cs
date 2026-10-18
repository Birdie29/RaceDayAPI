using Xunit;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace RaceDayAPI.UnitTesting
{
    public class RoleTest
    {
        [Fact]
        public void ParticipantRole_PassesValidation()
        {
            var role = new Role
            {
                role1 = "Participant"
            };

            var validationResults = Validate(role);

            Assert.Empty(validationResults);
        }

        [Fact]
        public void OrganiserRole_PassesValidation()
        {
            var role = new Role
            {
                role2 = "Organiser"
            };

            var context = new ValidationContext(role);
            var validationResults = new List<ValidationResult>();
            bool isValid = Validator.TryValidateObject(role, context, validationResults, true);
            Assert.False(isValid);
            Assert.NotEmpty(validationResults);
        }
    }
}