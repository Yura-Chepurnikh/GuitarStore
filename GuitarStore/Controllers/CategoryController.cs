using GuitarStore.Models;
using Microsoft.AspNetCore.Mvc;

namespace GuitarStore.Controllers
{
	public class CategoryController : Controller
	{
		private readonly Context _context;
		public CategoryController(Context context) 
		{
			_context = context;	
		}
		public IActionResult Category()
		{
			return View();
		}
		[HttpPost]
		public IActionResult Category(string categoryName)
		{
			var newCategory = new Category { CategoryName = categoryName };
			_context.Categories.Add(newCategory);
			_context.SaveChanges();

			return RedirectToAction("Create", "Guitar");
		}
		public IActionResult PresentCategory()
		{
			return View();
		}
	}
}
