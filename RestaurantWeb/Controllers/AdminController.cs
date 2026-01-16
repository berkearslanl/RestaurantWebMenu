using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Data.SqlClient.DataClassification;
using Microsoft.EntityFrameworkCore;
using RestaurantWeb.DAL.Context;
using RestaurantWeb.DAL.Entities;
using RestaurantWeb.Models;

namespace RestaurantWeb.Controllers
{
    [Authorize]
    public class AdminController : Controller
    {
        private readonly Context _context;

        public AdminController(Context context)
        {
            _context = context;
        }
        //dashboard sayfası
        public IActionResult Index()
        {
            ViewBag.menuitem = _context.MenuItems.Where(x => x.Status == true).Count();
            ViewBag.category = _context.Categories.Where(x => x.Status == true).Count();
            ViewBag.comment = _context.Comments.Count();
            ViewBag.newsletter = _context.Newsletters.Count();
            var values = _context.Comments.OrderByDescending(x => x.CommentId).Take(3).ToList();
            return View(values);
        }
        //kategori listesi sayfası
        public IActionResult CategoryIndex()
        {
            var values = _context.Categories.ToList();
            return View(values);
        }
        //kategori aktif pasif yapma
        public IActionResult CategoryGetPassive(int id)
        {
            var values = _context.Categories.Find(id);
            values.Status = false;
            _context.SaveChanges();
            return RedirectToAction("CategoryIndex");
        }
        public IActionResult CategoryGetActive(int id)
        {
            var values = _context.Categories.Find(id);
            values.Status = true;
            _context.SaveChanges();
            return RedirectToAction("CategoryIndex");
        }
        //kategori ekleme
        [HttpGet]
        public IActionResult CategoryAdd()
        {
            return View();
        }
        [HttpPost]
        public IActionResult CategoryAdd(RestaurantWeb.DAL.Entities.Category category)
        {
            _context.Categories.Add(category);
            _context.SaveChanges();
            return RedirectToAction("CategoryIndex");
        }
        //kategori güncelleme
        [HttpGet]
        public IActionResult CategoryUpdate(int id)
        {
            var values = _context.Categories.Find(id);
            return View(values);
        }
        [HttpPost]
        public IActionResult CategoryUpdate(RestaurantWeb.DAL.Entities.Category category)
        {
            _context.Categories.Update(category);
            _context.SaveChanges();
            return RedirectToAction("CategoryIndex");
        }
        //mail listesi
        public IActionResult MailList()
        {
            var values = _context.Newsletters.ToList();
            return View(values);
        }
        public IActionResult MailGetPassive(int id)
        {
            var values = _context.Newsletters.Find(id);
            values.Status = false;
            _context.SaveChanges();
            return RedirectToAction("MailList");
        }
        public IActionResult MailGetActive(int id)
        {
            var values = _context.Newsletters.Find(id);
            values.Status = true;
            _context.SaveChanges();
            return RedirectToAction("MailList");
        }
        //yorum listesi
        public IActionResult CommentList()
        {
            var values = _context.Comments.ToList();
            return View(values);
        }
        public IActionResult CommentDontSeeHome(int id)
        {
            var values = _context.Comments.Find(id);
            values.IsSeeHome = false;
            _context.SaveChanges();
            return RedirectToAction("CommentList");
        }
        public IActionResult CommentSeeHome(int id)
        {
            var values = _context.Comments.Find(id);
            values.IsSeeHome = true;
            _context.SaveChanges();
            return RedirectToAction("CommentList");
        }
        public IActionResult CommentDelete(int id)
        {
            var values = _context.Comments.Find(id);
            _context.Comments.Remove(values);
            _context.SaveChanges();
            return RedirectToAction("CommentList");
        }
        //bizim hikayemiz
        [HttpGet]
        public IActionResult OurStory()
        {
            var values = _context.Abouts.FirstOrDefault();
            return View(values);
        }
        [HttpPost]
        public IActionResult OurStory(About about)
        {
            var value = _context.Abouts.Find(about.AboutId);
            if (!string.IsNullOrEmpty(about.ImageUrl))
            {
                value.ImageUrl = about.ImageUrl;
            }
            value.Description = about.Description;
            value.DescriptionEn = about.DescriptionEn;
            value.DescriptionEs = about.DescriptionEs;
            _context.SaveChanges();
            return RedirectToAction("OurStory");
        }
        //galeri
        [HttpGet]
        public IActionResult GalleryPage()
        {
            var values = _context.Galeries.ToList();
            return View(values);
        }
        [HttpPost]
        public IActionResult GalleryPage(Galery galery)
        {
            _context.Galeries.Add(galery);
            _context.SaveChanges();
            return RedirectToAction("GalleryPage");
        }
        public IActionResult MakeActivePassive(int id)
        {
            var value = _context.Galeries.Find(id);
            if (value != null)
            {
                value.IsActive = !value.IsActive;
                _context.SaveChanges();
            }
            return RedirectToAction("GalleryPage");
        }
        public IActionResult DeletePhoto(int id)
        {
            var value = _context.Galeries.Find(id);
            _context.Galeries.Remove(value);
            _context.SaveChanges();
            return RedirectToAction("GalleryPage");
        }
        //menü ögeleri(yemekler)
        public IActionResult MenuItem()
        {
            var values = _context.MenuItems.Include(x => x.Category).ToList();
            return View(values);
        }
        public IActionResult Changestatus(int id)
        {
            var value = _context.MenuItems.Find(id);
            if (value != null)
            {
                value.Status = !value.Status;
                _context.SaveChanges();
            }
            return RedirectToAction("MenuItem");
        }
        public IActionResult Create()
        {
            // Dropdown içinde göstermek için kategorileri listele
            ViewBag.Categories = _context.Categories.Where(x => x.Status == true).ToList();
            return View();
        }

        [HttpPost]
        public IActionResult Create(MenuItem p)
        {
            p.Status = true;
            _context.MenuItems.Add(p);
            _context.SaveChanges();
            return RedirectToAction("MenuItem");
        }
        [HttpGet]
        public IActionResult MenuUpdate(int id)
        {
            ViewBag.Categories = _context.Categories.ToList();
            var values = _context.MenuItems.Find(id);
            return View(values);
        }
        [HttpPost]
        public IActionResult MenuUpdate(MenuItem p ,string Status)
        {
            var value = _context.MenuItems.Find(p.MenuItemId);
            value.Name = p.Name;
            value.NameEn= p.NameEn;
            value.NameEs= p.NameEs;
            value.Price = p.Price;
            value.Description = p.Description;
            value.DescriptionEn= p.DescriptionEn;
            value.DescriptionEs= p.DescriptionEs;
            value.CategoryId = p.CategoryId;
            value.Status = (Status == "true");
            _context.SaveChanges();
            return RedirectToAction("MenuItem");
        }
        //footer alanı
        public IActionResult Settings()
        {
            var viewModel = new SettingsViewModel
            {
                Contact = _context.Contacts.FirstOrDefault(),
                OpeningHour = _context.OpeningHours.FirstOrDefault(),
                SocialMedias = _context.SocialMedias.ToList()
            };
            return View(viewModel);
        }
        [HttpPost]
        public IActionResult SettingsUpdate(SettingsViewModel model)
        {
            if (!ModelState.IsValid)
            {
                _context.Contacts.Update(model.Contact);

                _context.OpeningHours.Update(model.OpeningHour);

                _context.SocialMedias.UpdateRange(model.SocialMedias);

                _context.SaveChanges();

                return RedirectToAction("Settings");
            }
            return View();
        }

    }
}
