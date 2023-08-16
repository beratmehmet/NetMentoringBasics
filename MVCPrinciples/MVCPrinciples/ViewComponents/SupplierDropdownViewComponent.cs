using System;
using Microsoft.AspNetCore.Mvc;
using MVCPrinciples.Models;

namespace MVCPrinciples.ViewComponents
{
	public class SupplierDropdownViewComponent : ViewComponent
	{
		private readonly MvcprinciplesContext _db;

		public SupplierDropdownViewComponent(MvcprinciplesContext db)
		{
			_db = db;
		}

        public async Task<IViewComponentResult> InvokeAsync(int id = -1)
        {
            var suppliers = _db.Suppliers.ToList();

			ViewBag.id = id;

            return View(suppliers);
        }
    }
}

