using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MVCPrinciples.Models;

namespace MVCPrinciples.Controllers
{
    public class ProductController : Controller
    {

        private MvcprinciplesContext _db;

        public ProductController(MvcprinciplesContext db)
        {
            _db = db;
            
        }

        public IActionResult Index()
        {
            var products = _db.Products.Include(p => p.Supplier).Include(p => p.Category).ToList();
            return View(products);
        }
    }
}
