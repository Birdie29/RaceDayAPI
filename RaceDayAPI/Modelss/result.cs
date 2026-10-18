namespace RaceDayAPI.Modelss
{
    public class Result
    {
        public int resultID { get; set; }
        public int position { get; set; }
        public string participantStatus { get; set; } = string.Empty;
        public TimeOnly finishTime { get; set; }
        public int registrationID { get; set; }
    }
}
