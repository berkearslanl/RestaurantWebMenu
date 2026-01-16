using RestaurantWeb.DAL.Entities;

namespace RestaurantWeb.Models
{
    public class MenuViewModel
    {
        public List<Category> Categories { get; set; }
    }

    public class Category
    {
        public int CategoryId { get; set; }
        public string CategoryName { get; set; }
        public string CategoryNameEn { get; set; }
        public string CategoryNameEs { get; set; }
        public List<MenuItem> MenuItems { get; set; }
    }
}
