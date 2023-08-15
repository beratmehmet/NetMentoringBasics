using Microsoft.AspNetCore.Mvc;
using MVCPrinciples.Models;

namespace MVCPrinciples.Controllers
{
    public class CategoryController : Controller
    {
        private MvcprinciplesContext _db;
        public CategoryController(MvcprinciplesContext db)
        {
            _db = db;
        }
        public IActionResult Index()
        {
            var categories = _db.Categories.ToArray();
            return View(categories);
        }
    }
}
