using System.ComponentModel.DataAnnotations;
namespace RaceDayAPI.Modelss
{
    public class Participant
    {
        public int participantID {get; set;}
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
        public string passwordHash { get; set; } = string.Empty;
    }
}
