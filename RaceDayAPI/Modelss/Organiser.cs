using System.ComponentModel.DataAnnotations;

namespace RaceDayAPI.Modelss
{
    public class Organiser
    {
        public int organiserID { get; set; }
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
        public string passwordHash { get; set; } = string.Empty;
    }
}
