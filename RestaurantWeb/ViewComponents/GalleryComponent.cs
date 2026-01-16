using Microsoft.AspNetCore.Mvc;
using RestaurantWeb.DAL.Context;

namespace RestaurantWeb.ViewComponents
{
    public class GalleryComponent:ViewComponent
    {
        private readonly Context _context;

        public GalleryComponent(Context context)
        {
            _context = context;
        }

        public IViewComponentResult Invoke()
        {
            var values = _context.Galeries.ToList();
            return View(values);
        }
    }
}
