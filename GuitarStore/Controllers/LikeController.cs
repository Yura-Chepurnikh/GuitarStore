using Microsoft.AspNetCore.Mvc;
using GuitarStore.Models;
using Microsoft.EntityFrameworkCore;

namespace GuitarStore.Controllers
{
	public class LikeController : Controller
	{
		private readonly Context _context;

		public LikeController(Context context)
		{
			_context = context;
		}

        public IActionResult Index()
        {
            int userId = HttpContext.Session.GetInt32("UserId") ?? 0;

            if (userId == 0)
            {
                return BadRequest("Invalid user");
            }

            var likedItems = _context.Likes
                .Include(l => l.Guitar)
                .Where(l => l.UserId == userId && l.IsLike)
                .ToList();

            return View(likedItems);
        }

        [HttpGet]
		public IActionResult Like()
		{
			try
			{
				int userId = HttpContext.Session.GetInt32("UserId") ?? 0;
				int guitarId = HttpContext.Session.GetInt32("GuitarId") ?? 0;

				if (userId == 0 || guitarId == 0)
				{
					return BadRequest("Invalid request parameters");
				}

				bool existingLike = _context.Likes.Any(l => l.UserId == userId && l.GuitarId == guitarId);

				if (existingLike)
				{
					return RedirectToAction("Exist", "Home");
				}

				Like like = new Like
				{
					GuitarId = guitarId,
					UserId = userId,
					IsLike = true,
				};

				_context.Likes.Add(like);
				_context.SaveChanges();

				return RedirectToAction("Index", "Like"); 
			}
			catch (Exception ex)
			{ 
				Console.WriteLine(ex.Message);
				return StatusCode(500, "Error when processing likes");
			}
		}
	}
}
