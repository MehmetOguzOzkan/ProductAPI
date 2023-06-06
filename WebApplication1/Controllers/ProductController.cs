using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Security.Cryptography.X509Certificates;
using System.Threading.Tasks;
using WebApplication1.Interfaces;
using WebApplication1.Models;
using WebApplication1.Models.Entity;
using WebApplication1.Models.Requests;
using WebApplication1.Repositories;

namespace WebApplication1.Controllers
{
	[Route("products")]
	public class ProductController : Controller
	{
		private readonly IProductRepository productRepository;

		public ProductController(IProductRepository productRepository)
		{
			this.productRepository = productRepository;
		}

		[HttpGet]
		public IActionResult GetAll(int page = 0, int pageSize = 10)
		{
			var list = productRepository.GetAll(page, pageSize);
			return Ok(list);
		}

		[HttpGet("{id}")]
		public IActionResult GetById(int id, bool withCategory = false)
		{
			var product = productRepository.GetById(id,withCategory);
			return Ok(product);
		}

		[HttpPost]
		public IActionResult Create([FromBody] ProductCreateRequest productCreateRequest)
		{
			productRepository.Add(productCreateRequest);
			return RedirectToAction("GetAll");
		}

		[HttpPut("{id}")]
		public IActionResult Update(int id, [FromBody] ProductUpdateRequest productUpdateRequest)
		{
			productRepository.Update(id, productUpdateRequest);
			return RedirectToAction("GetAll");

		}

		[HttpDelete("{id}")]
		public IActionResult Delete(int id)
		{
			productRepository.Delete(id);
			return RedirectToAction("GetAll");
		}

		[HttpGet("search")]
		public IActionResult Search(string name, int? categoryId, double? minPrice )
		{
			var list = productRepository.Search(name,categoryId,minPrice);
			return Ok(list);
		}
	}
}
