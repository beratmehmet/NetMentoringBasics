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

        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(Product product)
        {
            if (!ModelState.IsValid)
            {
                return View();
            }

            _productRepository.Add(product);

            return RedirectToAction("Index");
        }

        [HttpGet]
        public IActionResult Edit(int id)
        {
            var product = _productRepository.GetProductById(id);

            return View(product);
        }

        [HttpPost]
        public IActionResult Edit(Product product)
        {
            if (!ModelState.IsValid)
            {
                return View();
            }

            _productRepository.Edit(product);

            return RedirectToAction("Index");
        }
    }
}
