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

        public IViewComponentResult Invoke()
        {
            var suppliers = _db.Suppliers.ToList();
            return View(suppliers);
        }
    }
}

