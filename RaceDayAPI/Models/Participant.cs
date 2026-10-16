using System.ComponentModel.DataAnnotations;
namespace RaceDayAPI.Models
{
    public class Participant
    {
        public int participantID { get; set; }
        [Required(ErrorMessage = "Name is required")]
        public string participantName { get; set; } = string.Empty;
        [Required(ErrorMessage = "Surname is required")]
        public string participantSurname { get; set; }= string.Empty;
        [Required(ErrorMessage = "Email is required")]
        [EmailAddress(ErrorMessage = "Enter a vali email address")]
        public string email { get; set; } = string.Empty;

        [Phone(ErrorMessage = "Enter a valid phone number")]
        public string? phoneNumber { get; set; }
        [Required]
        public string passwordHash { get; set; } = string.Empty;
    }
}
