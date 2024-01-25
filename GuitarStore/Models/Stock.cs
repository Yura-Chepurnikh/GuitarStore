using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace GuitarStore.Models
{
	public class Stock
	{
		[Key]
		[DatabaseGenerated(DatabaseGeneratedOption.Identity)]
		public int StockId { get; set; }
		public string? StockName { get; set; }
		public string? StockAddress { get; set; }
		public ICollection<GuitarStore.Models.Guitar>? Guitars { get; set; }
	}
}