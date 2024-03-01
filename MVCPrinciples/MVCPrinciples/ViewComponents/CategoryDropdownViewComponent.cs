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

        public async Task<IViewComponentResult> InvokeAsync(int id = -1)
        {
			var categories = _db.Categories.ToList();

			ViewBag.id = id;

            return View(categories);
        }
    }
}

