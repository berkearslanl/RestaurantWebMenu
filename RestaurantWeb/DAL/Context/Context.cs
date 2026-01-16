using Microsoft.EntityFrameworkCore;
using RestaurantWeb.DAL.Entities;

namespace RestaurantWeb.DAL.Context
{
    public class Context:DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Server=LAPTOP-5Q1ARH5E;initial catalog=RestaurantDb;integrated security=true;trustservercertificate=true;");
        }

        public DbSet<About> Abouts { get; set; }
        public DbSet<Admin> Admins { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Comment> Comments { get; set; }
        public DbSet<Contact> Contacts { get; set; }
        public DbSet<Galery> Galeries { get; set; }
        public DbSet<HomePage> HomePages { get; set; }
        public DbSet<MenuItem> MenuItems { get; set; }
        public DbSet<Newsletter> Newsletters { get; set; }
        public DbSet<OpeningHour> OpeningHours { get; set; }
        public DbSet<SocialMedia> SocialMedias { get; set; }
    }
}
