using GuitarStore.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace GuitarStore.Controllers
{
	public class AddToShoppingCartController : Controller
	{
		private readonly Context _context;
		public AddToShoppingCartController(Context context)
		{
			_context = context;
		}

		public IActionResult AddView()
		{
			int userId = HttpContext.Session.GetInt32("UserId") ?? 0;

			if (userId == 0)
			{
				return BadRequest("Invalid user");
			}

			var addItems = _context.AddToShoppingCarts
				.Include(l => l.Guitar)
				.Where(l => l.UserId == userId && l.IsAdd)
				.ToList();

			return View(addItems);
		}

		[HttpGet]
		public IActionResult Add()
		{
			try
			{
				int userId = HttpContext.Session.GetInt32("UserId") ?? 0;
				int guitarId = HttpContext.Session.GetInt32("GuitarId") ?? 0;

				if (userId == 0 || guitarId == 0)
				{
					return BadRequest("Invalid request parameters");
				}

				bool existingAdd = _context.Likes.Any(l => l.UserId == userId && l.GuitarId == guitarId);

				if (existingAdd)
				{
					return BadRequest("already exists");
				}

				AddToShoppingCart addToShoppingCart = new AddToShoppingCart
				{
					GuitarId = guitarId,
					UserId = userId,
					IsAdd = true,
				};

				_context.AddToShoppingCarts.Add(addToShoppingCart);
				_context.SaveChanges();

				return RedirectToAction("AddView", "AddToShoppingCart"); 
			}
			catch (Exception ex) 
			{ 
				Console.WriteLine(ex.Message);
				return StatusCode(500, "Error when processing Add");
			}
		}
	}
}
