using System;
using Microsoft.AspNetCore.Mvc;
using MVCPrinciples.Models;

namespace MVCPrinciples.ViewComponents
{
	public class CategoryDropdownViewComponent : ViewComponent
	{
		private readonly MvcprinciplesContext _db;

		public CategoryDropdownViewComponent(MvcprinciplesContext db)
		{
			_db = db;
		}

        public IViewComponentResult Invoke()
        {
			var categories = _db.Categories.ToList();
            return View(categories);
        }
    }
}

