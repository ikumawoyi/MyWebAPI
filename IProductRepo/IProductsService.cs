using MyWebAPI.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MyWebAPI.IProductRepo
{
	 public interface IProductsService
	{
		public List<Product> GetProducts();

		public Product GetProduct(string id);

		public Product AddProduct(Product productItem);

		public Product UpdateProduct(string id, Product productItem);

		public string DeleteProduct(string id);
	}
}
