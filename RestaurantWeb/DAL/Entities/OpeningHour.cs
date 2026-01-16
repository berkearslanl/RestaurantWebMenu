namespace RestaurantWeb.DAL.Entities
{
    public class OpeningHour
    {
        public int OpeningHourId { get; set; }
        public string WeekdaysOpen { get; set; }
        public string WeekdaysClose { get; set; }
        public string WeekendsOpen { get; set; }
        public string WeekendsClose { get; set; }
    }
}
