namespace RaceDayAPI.Models
{
    public class Participant
    {
        public int participantID { get; set; }
        public string participantName { get; set; }
        public string participantSurname { get; set; }
        public string email { get; set; }
        public string phoneNumber { get; set; }
        public string passwordHash { get; set; }
    }
}
