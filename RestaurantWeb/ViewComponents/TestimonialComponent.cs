using Microsoft.AspNetCore.Mvc;
using RestaurantWeb.DAL.Context;
using System.Globalization;

namespace RestaurantWeb.ViewComponents
{
    public class TestimonialComponent:ViewComponent
    {
        private readonly Context _context;

        public TestimonialComponent(Context context)
        {
            _context = context;
        }

        public IViewComponentResult Invoke()
        {

            var currentCulture = CultureInfo.CurrentCulture.Name.Substring(0, 2).ToLower();

            ViewBag.SelectedLanguage = currentCulture;


            var values = _context.Comments.Where(x => x.IsSeeHome == true).ToList();
            return View(values);
        }
    }
}
