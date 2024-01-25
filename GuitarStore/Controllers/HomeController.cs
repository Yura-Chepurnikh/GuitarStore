using GuitarStore.Models;
using Microsoft.AspNetCore.Mvc;

namespace GuitarStore.Controllers
{
	public class HomeController : Controller
	{
		private readonly Context _context;	
		
		public HomeController(Context context)
		{
            _context = context;
        }
		public IActionResult Index()
		{
			var guitars = _context?.Guitars?.ToList();
			return View(guitars);
		}

		public IActionResult Empty()
		{
			return View();	
		}

		[HttpPost]
		public IActionResult Find(string searchText)
		{
			var foundGuitar = _context.Guitars.FirstOrDefault(g => g.GuitarModel.Contains(searchText));
			Console.WriteLine(foundGuitar);

			if (foundGuitar == null)
			{
				return RedirectToAction("Empty", "Home");
			}
			else
			{ 
				HttpContext.Session.SetInt32("GuitarId", foundGuitar.GuitarId);
				return RedirectToAction("Details", "Home");
			}
		}

		public IActionResult Details(int id)
		{
			int guitarId = HttpContext.Session.GetInt32("GuitarId") ?? 0;

			if (guitarId != 0)
			{
				var foundGuitar = _context.Guitars.Find(guitarId);
				if (foundGuitar == null)
				{
					return NotFound();
				}
				return View(foundGuitar);
			}
			else
			{
				var guitar = _context?.Guitars?.Find(id);
				if (guitar == null)
				{
					return NotFound();
				}
				return View(guitar);
			}
		}
		public IActionResult IndexIn(string category)
		{
			var guitars = _context.Guitars.Where(g => g.Category.CategoryName == category).ToList();

			return View(guitars);
		}

		public IActionResult Exist()
		{
			return View();	
		}
		public IActionResult AboutUs()
		{
			return View();
		}
	}
}
