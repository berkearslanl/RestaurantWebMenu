using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using RestaurantWeb.DAL.Context;
using RestaurantWeb.Models;

namespace RestaurantWeb.ViewComponents
{
    public class FooterComponent : ViewComponent
    {
        private readonly Context _context;

        public FooterComponent(Context context)
        {
            _context = context;
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            var model = new FooterViewModel
            {
                Contacts = await _context.Contacts.FirstOrDefaultAsync(),
                OpeningHours = await _context.OpeningHours.ToListAsync(),
                SocialMedias = await _context.SocialMedias.ToListAsync(),
            };
            return View(model);
        }
    }
}
