namespace RaceDayAPI.Modelss
{
    public class Category
    {
        public string categoryID { get; set; } = string.Empty;
        public string categoryName { get; set; } = string.Empty;
        public decimal categoryDistance { get; set; }
        public decimal entryFee { get; set; }
        public int eventID { get; set; }
    }
}
