using Microsoft.AspNetCore.Mvc;
using GuitarStore.Models;
using System.Linq;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using GuitarStore.Controllers;

[AllowAnonymous]
public class LoginController : Controller
{
	private readonly Context _context;

	public LoginController(Context context)
	{
		_context = context;
	}

	public IActionResult Index(int guitarId, string action)
	{
		HttpContext.Session.SetString("Action", action);
		HttpContext.Session.SetInt32("GuitarId", guitarId);
		return View();
	}

	[HttpPost]
	public IActionResult Login([FromForm] User user)
	{
		try
		{
			var existingUser = _context.Users.FirstOrDefault(u => u.Email == user.Email);

			if (existingUser == null || !PasswordHasher.VerifyPassword(user.Password, existingUser.PasswordHash))
			{
				return BadRequest("Неверный email или пароль");
			}

			HttpContext.Session.SetInt32("UserId", existingUser.UserId);

			int guitarId = HttpContext.Session.GetInt32("GuitarId") ?? 0;
			HttpContext.Session.SetInt32("GuitarId", guitarId);

			string action = HttpContext.Session.GetString("Action");

            if (action == "Like")
			{
				return RedirectToAction("Like", "Like");
			}
			else if (action == "Order") {
				return RedirectToAction("Order", "Order");
			}
			else if (action == "Add")
			{
				return RedirectToAction("Add", "AddToShoppingCart");
			}
			else if (action == "OrderView")
			{
				return RedirectToAction("Order", "Order");
			}
			else if (action == "LikeView")
			{
				return RedirectToAction("Index", "Like");
			}
			else
			{
				return RedirectToAction("AddView", "AddToShoppingCart");
			}
		}
		catch
		{
			return StatusCode(500, "Ошибка при аутентификации");
		}
	}


}


