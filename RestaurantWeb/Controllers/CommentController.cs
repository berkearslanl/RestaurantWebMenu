using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using RestaurantWeb.DAL.Context;
using RestaurantWeb.DAL.Entities;

namespace RestaurantWeb.Controllers
{
    public class CommentController : Controller
    {
        private readonly Context _context;

        public CommentController(Context context)
        {
            _context = context;
        }
        [HttpPost]
        public IActionResult LeaveComment(Comment comment)
        {
            comment.IsSeeHome = false;
            _context.Comments.Add(comment);
            _context.SaveChanges();
            TempData["commentSuccess"] = "true";
            return RedirectToAction("Index", "Main");

        }
    }
}
