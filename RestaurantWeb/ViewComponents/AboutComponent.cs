using Microsoft.AspNetCore.Mvc;
using RestaurantWeb.DAL.Context;
using System.Globalization;

namespace RestaurantWeb.ViewComponents
{
    public class AboutComponent:ViewComponent
    {
        private readonly Context _context;

        public AboutComponent(Context context)
        {
            _context = context;
        }

        public IViewComponentResult Invoke()
        {
            var currentCulture = CultureInfo.CurrentCulture.Name.Substring(0, 2).ToLower();

            ViewBag.SelectedLanguage = currentCulture;


            var values = _context.Abouts.ToList();
            return View(values);
        }
    }
}
