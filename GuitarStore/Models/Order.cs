using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace GuitarStore.Models
{
	public class Order
	{
		[Key]
		[DatabaseGenerated(DatabaseGeneratedOption.Identity)]
		public int OrderId { get; set; }
		public bool IsOrder { get; set; }

		public int UserId { get; set; }
		public User? User { get; set; }

		public int GuitarId { get; set; }
		public Guitar? Guitar { get; set; }
	}
}