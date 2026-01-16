using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using RestaurantWeb.DAL.Context;
using System.Globalization;

namespace RestaurantWeb.ViewComponents
{
    public class MenuComponent:ViewComponent
    {
        private readonly Context _context;

        public MenuComponent(Context context)
        {
            _context = context;
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            var currentCulture = CultureInfo.CurrentCulture.Name.Substring(0, 2).ToLower();

            ViewBag.SelectedLanguage = currentCulture;

            var values = await _context.Categories
                                       .Include(x => x.MenuItems)
                                       .Where(x=>x.Status==true)
                                       .ToListAsync();

            return View(values);
        }
    }
}
