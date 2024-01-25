using GuitarStore.Models;
using Microsoft.AspNetCore.Mvc;

namespace GuitarStore.Controllers
{
	public class OrderController : Controller
	{
		private readonly Context _context;
		public OrderController(Context context)
		{
			_context = context;
		}
		public IActionResult OrderSuccess()
		{
			return View();
		}
		[HttpGet]
		public IActionResult Order()
		{
			try
			{
				int userId = HttpContext.Session.GetInt32("UserId") ?? 0;
				int guitarId = HttpContext.Session.GetInt32("GuitarId") ?? 0;

				// Проверка, чтобы не были 0
				if (userId == 0 || guitarId == 0)
				{
					return RedirectToAction("Exist", "Home");
				}

				// Проверяем существования такого заказа
				bool existingOrder = _context.Likes.Any(l => l.UserId == userId && l.GuitarId == guitarId);

				Order order = new Order
				{
					GuitarId = guitarId,
					UserId = userId,
					IsOrder = true,
				};

				var foundGuitar = _context.Guitars.Find(guitarId);
				foundGuitar.Count--; // Уменьшаем количество гитар 

				_context.Orders.Add(order);
				_context.SaveChanges();

				return RedirectToAction("OrderSuccess", "Order"); // или куда вам нужно перенаправить после успешного лайка
			}
			catch (Exception ex)
			{
				// Обработка ошибок
				Console.WriteLine(ex.Message);
				return StatusCode(500, "Error when processing Orders");
			}
		}
	}
}
