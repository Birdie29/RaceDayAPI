namespace RaceDayAPI.Modelss
{
    public class result
    {
        public int resultID { get; set; }
        public int position { get; set; }
        public string participantStatus { get; set; }
        public TimeOnly finishTime { get; set;}
        public int registrationID { get; set; }
    }
}
