namespace RaceDayAPI.Modelss
{
    public class Registration
    {
        public int registrationID { get; set; }
        public DateTime registrationDate { get; set; }
        public string registrationChannel { get; set; } = string.Empty;
        public int participantID { get; set; }
        public int eventID { get; set; }
        public int categoryID { get; set; }
    }
}
