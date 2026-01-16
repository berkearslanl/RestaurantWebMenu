using Microsoft.AspNetCore.Mvc;
using RestaurantWeb.DAL.Context;

namespace RestaurantWeb.ViewComponents
{
    public class HeaderComponent:ViewComponent
    {
        private readonly Context _context;

        public HeaderComponent(Context context)
        {
            _context = context;
        }

        public IViewComponentResult Invoke()
        {
            var values = _context.Contacts.FirstOrDefault();
            return View(values);
        }
    }
}
