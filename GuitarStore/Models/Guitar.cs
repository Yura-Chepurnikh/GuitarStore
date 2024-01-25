using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace GuitarStore.Models
{
	public class Guitar
	{
		[Key]
		[DatabaseGenerated(DatabaseGeneratedOption.Identity)]
		public int GuitarId { get; set; } // primary key
		public string? GuitarModel { get; set; }
		public decimal Price { get; set; }
		public string? GuitarCompany { get; set; }
		public string? GuitarDescription { get; set; }
		public string? Guitarwood { get; set; }
		public string? GuitarPickups { get; set; }
		public int? NumberOfStrings { get; set; }
		public string? StringMaterials { get; set; }
		public int? Count { get; set; }
		public string? PhotoUrl { get; set; }

		public string? ListPhotoUrl1 { get; set; }
		public string? ListPhotoUrl2 { get; set; }
		public string? ListPhotoUrl3 { get; set; }
		public string? ListPhotoUrl4 { get; set; }
		public string? ListPhotoUrl5 { get; set; }
		public string? ListPhotoUrl6 { get; set; }

		public int LikeId { get; set; }
		public Like? Like { get; set; }

		public int UserId { get; set; }
		public User? User { get; set; }

		public int CategoryId { get; set; }
		public Category? Category { get; set; }

		public int OrderId { get; set; }
		public Order? Order { get; set; }

		public int StockId { get; set; }
		public Stock? Stock { get; set; }

		public int AddToShoppingCartId { get; set; }
		public AddToShoppingCart? AddToShoppingCart { get; set; }
	}
}

