using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using MVCPrinciples.Models;

namespace MVCPrinciples.Controllers
{
    public class ProductController : Controller
    {
        private readonly SettingsModel _settings;

        private readonly IProductRepository _productRepository;
        public ProductController(IOptions<SettingsModel> options, IProductRepository productRepository)
        {

            _settings = options.Value;
            _productRepository = productRepository;
        }

        public IActionResult Index()
        {
            IEnumerable<Product> products = _productRepository.LimitedProducts(_settings.NumberOfProducts);
            return View(products);
        }
    }
}
