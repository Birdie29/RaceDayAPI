using System.ComponentModel.DataAnnotations;

namespace RaceDayAPI.Modelss
{
    public class LoginRequest
    {
        [Required]
        [EmailAddress]
        public string email { get; set; } = string.Empty;

        [Required]
        public string password { get; set; } = string.Empty;
    }

    public class RegisterOrganiserRequest
    {
        [Required]
        public string organiserName { get; set; } = string.Empty;

        [Required]
        public string organiserSurname { get; set; } = string.Empty;

        [Required]
        [EmailAddress]
        public string email { get; set; } = string.Empty;

        [Required]
        [Phone]
        public string phoneNumber { get; set; } = string.Empty;

        [Required]
        public string password { get; set; } = string.Empty;
    }

    public class RegisterParticipantRequest
    {
        [Required]
        public string participantName { get; set; } = string.Empty;

        [Required]
        public string participantSurname { get; set; } = string.Empty;

        [Required]
        [EmailAddress]
        public string email { get; set; } = string.Empty;

        [Required]
        [Phone]
        public string phoneNumber { get; set; } = string.Empty;

        [Required]
        public string password { get; set; } = string.Empty;
    }
}
