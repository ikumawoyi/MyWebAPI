using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using MyWebAPI.IProductRepo;
using MyWebAPI.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MyWebAPI.Controllers
{
	[ApiController]
	[Route("[controller]")]
	public class ProductsController : ControllerBase
	{

		private ILogger _logger;
		private IProductsService _service;


		public ProductsController(ILogger<ProductsController> logger, IProductsService service)
		{
			_logger = logger;
			_service = service;

		}

		[HttpGet("/api/products")]
		public ActionResult<List<Product>> GetProducts()
		{
			return _service.GetProducts();
		}

		[HttpGet("/api/products/{id}")]
		public ActionResult<Product> GetProducts(string id)
		{
			return _service.GetProduct(id);
		}

		[HttpPost("/api/products")]
		public ActionResult<Product> AddProduct(Product product)
		{
			_service.AddProduct(product);
			return product;
		}

		[HttpPut("/api/products/{id}")]
		public ActionResult<Product> UpdateProduct(string id, Product product)
		{
			_service.UpdateProduct(id, product);
			return product;
		}

		[HttpDelete("/api/products/{id}")]
		public ActionResult<string> DeleteProduct(string id)
		{
			_service.DeleteProduct(id);
			//_logger.LogInformation("products", _products);
			return id;
		}
	}
}
