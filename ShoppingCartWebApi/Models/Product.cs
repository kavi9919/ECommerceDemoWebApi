using System.ComponentModel.DataAnnotations;

namespace ShoppingCartWebApi.Models
{
	public class Product
	{

		[Key]
        public int Id { get; set; }

		public string Name { get; set; }

		public string Image { get; set; }

		public decimal ActualPrice { get; set; }

		public decimal DiscountedPrice { get; set; }
    }
}
