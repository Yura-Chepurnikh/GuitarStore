using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace GuitarStore.Models
{
	public class Like
	{
		[Key]
		[DatabaseGenerated(DatabaseGeneratedOption.Identity)]
		public int LikeId { get; set; }
		public bool IsLike { get; set; }
		public int UserId { get; set; }
		public User? User { get; set; }
		public int GuitarId { get; set; }
		public Guitar? Guitar { get; set; }
	}
}