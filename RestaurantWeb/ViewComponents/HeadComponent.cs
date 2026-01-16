using Microsoft.AspNetCore.Mvc;

namespace RestaurantWeb.ViewComponents
{
    public class HeadComponent:ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            return View();
        }
    }
}
