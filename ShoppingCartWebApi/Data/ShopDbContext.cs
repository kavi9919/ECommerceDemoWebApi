using Microsoft.EntityFrameworkCore;
using ShoppingCartWebApi.Models;

namespace ShoppingCartWebApi.Data
{
	public class ShopDbContext : DbContext
	{
		public ShopDbContext(DbContextOptions<ShopDbContext> options) : base(options)
		{

		}
		public DbSet<Product> Products { get; set; }

		protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
		{
			//db name is lms
			optionsBuilder.UseSqlServer("Data Source=.; initial Catalog=ShoppingCart ; User Id=sa; password=1234; TrustServerCertificate= True");
		}
	}
}
           