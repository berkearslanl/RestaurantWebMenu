namespace RestaurantWeb.DAL.Entities
{
    public class Category
    {
        public int CategoryId { get; set; }
        public string CategoryName { get; set; }
        public string CategoryNameEn { get; set; }
        public string CategoryNameEs{ get; set; }
        public bool Status { get; set; }

        public List<MenuItem> MenuItems { get; set; }
    }
}
