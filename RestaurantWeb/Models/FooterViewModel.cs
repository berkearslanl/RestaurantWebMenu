using RestaurantWeb.DAL.Entities;

namespace RestaurantWeb.Models
{
    public class FooterViewModel
    {
        public List<SocialMedia> SocialMedias { get; set; }
        public List<OpeningHour> OpeningHours { get; set; }
        public Contact Contacts { get; set; }

        public int NewsletterId { get; set; }
        public string Mail { get; set; }
        public bool Status { get; set; }
    }
}
