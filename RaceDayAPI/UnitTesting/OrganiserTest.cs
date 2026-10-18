using System.Net;
using System.Net.Http;
using System.Net.Http.Json;
using System.Threading.Tasks;
using Xunit;

namespace RaceDayAPI.UnitTesting
{
    public class ParticipantTest
    {
        [Fact]
        public void ValidParticipant_PassesValidation()
        {
            var participant = new Participant
            {
                participantName = "John",
                participantSurname = "Doe",
                email = "john.doe@example.com",
                phoneNumber = "123-456-7890",
                passwordHash = "hashed-password"
            };


            var validationResults = Validate(participant);

            Assert.Empty(validationResults);
        }

        [Fact]
        public void ParticipantWithMissingName_FailsRequiredValidation()
        {
            var participant = new Participant
            {
                participantName = string.Empty,
                participantSurname = "Doe",
                email = "       
                passwordHash = "hashed-password"
            };

            var context = new ValidationContext(participant);
            var validationResults = new List<ValidationResult>();
            bool isValid = Validator.TryValidateObject(participant, context, validationResults, true);
            Assert.False(isValid);
            Assert.NotEmpty(validationResults);
        }

}