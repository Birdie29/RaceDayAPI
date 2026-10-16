namespace RaceDayAPI.Modelss
{
    public class raceEvent
    { public int eventID {get; set;}
        public string eventName {get; set; }
        public string eventDescription {get; set;}
        public DateTime eventDate { get; set; }
        public string eventLocation { get; set; }
        public decimal eventDistance { get; set; }
        public string eventType { get; set; }
        public int organiserID { get; set; }
    }
}
