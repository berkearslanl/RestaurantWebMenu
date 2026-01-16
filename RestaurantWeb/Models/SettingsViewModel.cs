using RestaurantWeb.DAL.Entities;

namespace RestaurantWeb.Models
{
    public class SettingsViewModel
    {
        public Contact Contact { get; set; }
        public OpeningHour OpeningHour { get; set; }

        // Sosyal medya bir liste olduğu için List olarak tanımlıyoruz
        public List<SocialMedia> SocialMedias { get; set; }
    }
}
