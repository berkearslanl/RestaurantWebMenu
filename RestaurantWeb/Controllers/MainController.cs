using Microsoft.AspNetCore.Mvc;

namespace RestaurantWeb.Controllers
{
    public class MainController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
        [Route("Error/{code}")]
        public IActionResult ErrorPage(int code)
        {
            ViewBag.Code = code;
            return View();
        }
    }
}
