namespace RaceDayAPI.Modelss
{
    public class registration
    {
        public int registrationID { get; set; }
        public DateTime registrationDate { get; set; }
        public string registrationChannel { get; set; }
        public int participantID { get; set; }
        public int eventID { get; set; }
        public int categoryID { get; set; }
    }
}
