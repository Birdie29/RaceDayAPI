using System.ComponentModel.DataAnnotations;
using RaceDayAPI.Modelss;
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
            participantName = string.Empty,
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
            email = "not-an-email",
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
