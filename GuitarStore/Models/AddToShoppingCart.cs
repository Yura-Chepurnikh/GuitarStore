using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace GuitarStore.Models
{
	public class AddToShoppingCart
	{
		[Key]
		[DatabaseGenerated(DatabaseGeneratedOption.Identity)]
		public int AddToShoppingCartId { get; set; }
		public bool IsAdd { get; set; }
		public int UserId { get; set; }
		public int Quantity { get; set; }
		public User? User { get; set; }
		public int GuitarId { get; set; }
		public Guitar? Guitar { get; set; }
	}
}