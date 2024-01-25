using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace GuitarStore.Models
{
	public class Category
	{
		[Key]
		[DatabaseGenerated(DatabaseGeneratedOption.Identity)]
		public int CategoryId { get; set; } // primary key

		[Required]
		[MaxLength(255)]
		public string CategoryName { get; set; }
		public ICollection<Guitar>? Guitars { get; set; } // navigation property 
	}
}