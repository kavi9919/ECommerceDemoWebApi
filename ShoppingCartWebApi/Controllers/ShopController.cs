using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ShoppingCartWebApi.Data;
using ShoppingCartWebApi.Models;
using System.Data.SqlClient;

namespace ShoppingCartWebApi.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class ShopController : ControllerBase
	{

		private readonly ShopDbContext _shopDbContext;

        public ShopController(ShopDbContext shopDbContext)
        {
            _shopDbContext = shopDbContext;
        }

		[HttpGet]
		[Route("GetProduct")]

		public async Task<IEnumerable<Product>> GetProduct()
		{
			return await _shopDbContext.Products.ToListAsync();
		}



		[HttpPost]
		[Route("PostProduct")]
		public async Task<Product> AddProduct(Product product)
		{
			_shopDbContext.Products.Add(product);
			await _shopDbContext.SaveChangesAsync();
			return product;
		}

	}


}
