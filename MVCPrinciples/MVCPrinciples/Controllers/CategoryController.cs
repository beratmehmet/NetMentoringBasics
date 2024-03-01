using Microsoft.AspNetCore.Mvc;
using MVCPrinciples.Models;

namespace MVCPrinciples.Controllers
{
    public class CategoryController : Controller
    {
        private ICategoryRepository _categoryRepository;
        public CategoryController(ICategoryRepository categoryRepository)
        {
            _categoryRepository = categoryRepository;
        }
        public IActionResult Index()
        {
            var categories = _categoryRepository.GetCategories;
            return View(categories);
        }
    }
}
