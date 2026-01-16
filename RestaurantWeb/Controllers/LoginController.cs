using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Mvc;
using RestaurantWeb.DAL.Context;
using RestaurantWeb.DAL.Entities;
using System.Security.Claims;

namespace RestaurantWeb.Controllers
{
    public class LoginController : Controller
    {
        private readonly Context _context;

        public LoginController(Context context)
        {
            _context = context;
        }

        public async Task<IActionResult> Index(Admin admin)
        {
            var value = _context.Admins.FirstOrDefault(x => x.Username == admin.Username && x.Password == admin.Password);
            if (value != null)
            {
                var claims = new List<Claim>
                {
                    new Claim(ClaimTypes.Name,admin.Username)
                };
                
                var useridentity = new ClaimsIdentity(claims,"Login");

                ClaimsPrincipal principal = new ClaimsPrincipal(useridentity);  

                await HttpContext.SignInAsync(principal);

                return RedirectToAction("Index", "Admin");
            }
            return View();
        }
        public async Task<IActionResult> LogOut()
        {
            await HttpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);
            return RedirectToAction("Index");
        }
    }
}
