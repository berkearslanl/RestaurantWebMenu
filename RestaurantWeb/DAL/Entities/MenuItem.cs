using System.ComponentModel.DataAnnotations.Schema;

namespace RestaurantWeb.DAL.Entities
{
    public class MenuItem
    {
        public int MenuItemId { get; set; }
        public string Name { get; set; }
        public string NameEn { get; set; }
        public string NameEs { get; set; }
        public string Description { get; set; }
        public string DescriptionEn { get; set; }
        public string DescriptionEs { get; set; }
        public decimal Price { get; set; }
        public bool Status { get; set; }

        //reletion with category
        public int CategoryId { get; set; }
        [ForeignKey("CategoryId")]
        public Category Category { get; set; }
    }
}
