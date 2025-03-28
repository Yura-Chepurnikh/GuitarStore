using System.ComponentModel.DataAnnotations;

namespace GuitarStore.Models
{
	public class User
	{
		public int UserId { get; set; } // primary key
		public string? UserName { get; set; }
		public string? Password { get; set; }
		public string? Email { get; set; }
		public string? PhoneNumber { get; set; }
		public bool UserConfirmed { get; set; }

		[Required]
		public string? PasswordHash { get; set; }
		public void SetPassword(string password)
		{
			this.PasswordHash = BCrypt.Net.BCrypt.HashPassword(password); 
		}
		public bool VerifyPassword(string enteredPassword)
		{
			return BCrypt.Net.BCrypt.Verify(enteredPassword, this.PasswordHash);   
		}
		public ICollection<Order>? Orders { get; set; } 
		public ICollection<Like>? Likes { get; set; }
		public ICollection<AddToShoppingCart>? addToShoppingCarts { get; set; }
	}
}