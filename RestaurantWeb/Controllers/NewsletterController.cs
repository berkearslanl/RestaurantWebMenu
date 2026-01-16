using Microsoft.AspNetCore.Mvc;
using RestaurantWeb.DAL.Context;
using RestaurantWeb.DAL.Entities;

namespace RestaurantWeb.Controllers
{
    public class NewsletterController : Controller
    {
        private readonly Context _context;

        public NewsletterController(Context context)
        {
            _context = context;
        }
        [HttpPost]
        public IActionResult Subscribe(Newsletter newsletter)
        {
            newsletter.Status = true;
            _context.Newsletters.Add(newsletter);
            _context.SaveChanges();
            TempData["SubscribeSuccess"] = "true";
            return RedirectToAction("Index","Main");
        }
    }
}
