using System.ComponentModel.DataAnnotations;
using RaceDayAPI.Modelss;
using System.Net;
using System.Net.Http;
using System.Net.Http.Json;
using System.Threading.Tasks;
using Xunit;

namespace RaceDayAPI.UnitTesting;

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
            participantName = null,
            participantSurname = "Doe",
            email = "john.doe@example.com",
            phoneNumber = "123-456-7890",
            passwordHash = "hashed-password"
        };

        var validationResults = Validate(participant);

        Assert.Contains(validationResults, result =>
            result.MemberNames.Contains(nameof(Participant.participantName)));
    }

    [Fact]
    public void ParticipantWithInvalidEmail_FailsEmailValidation()
    {
        var participant = new Participant
        {
            participantName = "John",
            participantSurname = "Doe",
            email = "applesandoranges.com", // Invalid email format
            phoneNumber = "123-456-7890",
            passwordHash = "hashed-password"
        };

        var validationResults = Validate(participant);

        Assert.Contains(validationResults, result =>
            result.MemberNames.Contains(nameof(Participant.email)));
    }

    private static List<ValidationResult> Validate(Participant participant)
    {
        var validationResults = new List<ValidationResult>();
        Validator.TryValidateObject(
            participant,
            new ValidationContext(participant),
            validationResults,
            validateAllProperties: true);

        return validationResults;
    }
}
