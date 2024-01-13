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

		[HttpGet]
		[Route("GetProduct/{id}")]
		public async Task<IActionResult> GetStudentById(int id)
		{
			var product = await _shopDbContext.Products.FindAsync(id);

			if (product == null)
			{
				return NotFound(); // Return 404 Not Found if the student with the specified ID is not found.
			}

			return Ok(product); // Return 200 OK with the student information if found.
		}

			[HttpPost]
		[Route("PostProduct")]
		public async Task<Product> AddProduct(Product product)
		{
			_shopDbContext.Products.Add(product);
			await _shopDbContext.SaveChangesAsync();
			return product;
		}

		[HttpPatch]
		[Route("UpdateProduct/{id}")]

		public async Task<Product> UpdateStudent(Product product)
		{
			_shopDbContext.Entry(product).State = EntityState.Modified;
			await _shopDbContext.SaveChangesAsync();
			return product;
		}

		[HttpDelete]
		[Route("DeleteProduct/{id}")]

		public bool DeleteStudent(int id)
		{
			bool a = false;
			var product = _shopDbContext.Products.Find(id);
			if (product != null)
			{
				a = true;
				_shopDbContext.Entry(product).State = EntityState.Deleted;
				_shopDbContext.SaveChanges();
			}
			else
			{
				a = false;
			}
			return a;
		}

	}




}
