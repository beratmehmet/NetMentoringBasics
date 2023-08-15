using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using MVCPrinciples.Models;

namespace MVCPrinciples.Controllers
{
    public class ProductController : Controller
    {

        private MvcprinciplesContext _db;

        private readonly SettingsModel _settings;

        public ProductController(MvcprinciplesContext db, IOptions<SettingsModel> options)
        {
            _db = db;

            _settings = options.Value;

        }

        public IActionResult Index()
        {
            IEnumerable<Product> products;
            if (_settings.NumberOfProducts > 0 )
            {
                products = _db.Products.Include(p => p.Supplier).Include(p => p.Category).Take(_settings.NumberOfProducts).ToList();
            }
            else
            {
                products = _db.Products.Include(p => p.Supplier).Include(p => p.Category).ToList();
            }
            return View(products);
        }
    }
}
