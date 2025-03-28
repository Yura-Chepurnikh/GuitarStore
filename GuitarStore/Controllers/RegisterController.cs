using GuitarStore.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

[AllowAnonymous]
public class RegisterController : Controller
{
	private readonly Context _context;

	public RegisterController(Context context)
	{
		_context = context;
	}

	public IActionResult Register()
	{
		return View();	
	}
	public IActionResult RegisterSuccess()
	{
		return View();
	}

	[HttpPost]
	public IActionResult Register([FromForm] User user)
	{
		try
		{
			if (_context.Users.Any(u => u.Email == user.Email))
			{
				return BadRequest("The user with this email already exists");
			}
			var newUser = new User
			{
				UserName = user.Email,
				Email = user.Email,
				Password = user.Password,
				PasswordHash = BCrypt.Net.BCrypt.HashPassword(user.Password),
				PhoneNumber = user.PhoneNumber,
				UserConfirmed = user.UserConfirmed,
			};
			_context.Users.Add(newUser);
			_context.SaveChanges();

			return RedirectToAction("RegisterSuccess", "Register"); 
		}
		catch (DbUpdateException)
		{
			return StatusCode(500, "Error during registration");
		}
	}
}
public class PasswordHasher
{
	public static string HashPassword(string password)
	{
		return BCrypt.Net.BCrypt.HashPassword(password);
	}

	public static bool VerifyPassword(string enteredPassword, string hashedPassword)
	{
		return BCrypt.Net.BCrypt.Verify(enteredPassword, hashedPassword);
	}
}
