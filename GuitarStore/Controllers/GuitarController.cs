using GuitarStore.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Security.Principal;

public class GuitarController : Controller
{
    private readonly Context _context;
    public GuitarController(Context context)
    {
        _context = context;
    }
	public IActionResult Create()
    {
        return View();
    }

	[HttpPost]
    public IActionResult Create(Guitar guitar)
    {
		var latestCategory = _context.Categories
			.OrderByDescending(c => c.CategoryId)
			.FirstOrDefault();

		var latestUser = _context.Users
			.OrderByDescending(c => c.UserId)
			.FirstOrDefault();

        if (latestUser != null)
        {
            var latestOrder = _context.Orders
                .Where(o => o.UserId == latestUser.UserId && o.IsOrder)
                .OrderByDescending(o => o.OrderId)
                .FirstOrDefault();

            if (latestOrder == null)
            {
                latestOrder = new Order
                {
                    UserId = latestUser.UserId,
                    IsOrder = false,
                
                };
                _context.Orders.Add(latestOrder);
            }

			var latestStock = _context.Stocks
			.OrderByDescending(c => c.StockId)
			.FirstOrDefault();

			if (ModelState.IsValid)
			{
				try
				{
					var newGuitar = new Guitar
					{
						GuitarModel = guitar.GuitarModel,
						GuitarCompany = guitar.GuitarCompany,
						GuitarPickups = guitar.GuitarPickups,
						GuitarDescription = guitar.GuitarDescription,
						Guitarwood = guitar.Guitarwood,
						NumberOfStrings = guitar.NumberOfStrings,
						PhotoUrl = guitar.PhotoUrl,	
						ListPhotoUrl1 = guitar.ListPhotoUrl1,
						ListPhotoUrl2 = guitar.ListPhotoUrl2,
						ListPhotoUrl3 = guitar.ListPhotoUrl3,
						ListPhotoUrl4 = guitar.ListPhotoUrl4,
						ListPhotoUrl5 = guitar.ListPhotoUrl5,
						ListPhotoUrl6 = guitar.ListPhotoUrl6,
						Price = guitar.Price,
						Order = latestOrder,
						Category = latestCategory,
						Stock = latestStock,
						User = latestUser,
					};
					_context?.Guitars?.Add(newGuitar);
					_context?.SaveChanges();
					return RedirectToAction("Index", "Home");
				}
				catch (Exception ex)
				{
					Console.WriteLine($"An error when creating a guitar: {ex.Message}");
					return View(guitar);
				}
			}
			else
			{
				foreach (var modelState in ModelState.Values)
				{
					foreach (var error in modelState.Errors)
					{
						Console.WriteLine($"Model error: {error.ErrorMessage}");
					}
				}

				bool isModelValid = TryValidateModel(guitar);
				Console.WriteLine($"Model is valid: {isModelValid}");

				return View(guitar);
			}
		}
		return View(guitar);	
    }
}