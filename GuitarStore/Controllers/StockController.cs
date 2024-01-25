using GuitarStore.Models;
using Microsoft.AspNetCore.Mvc;

namespace GuitarStore.Controllers
{
	public class StockController : Controller
	{
		private readonly Context _context;
		public StockController(Context context)
		{
			_context = context;
		}
		public IActionResult Stock()
		{
			return View();
		}
		[HttpPost]
		public IActionResult Stock(string stockAddress)
		{
			var newStock = new Stock { StockAddress = stockAddress };
			_context.Stocks.Add(newStock);
			_context.SaveChanges();

			return RedirectToAction("Category", "Category");
		}
	}
}
