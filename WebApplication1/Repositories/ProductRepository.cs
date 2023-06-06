using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using WebApplication1.Interfaces;
using WebApplication1.Models;
using WebApplication1.Models.Entity;
using WebApplication1.Models.Requests;

namespace WebApplication1.Repositories
{
    public class ProductRepository : IProductRepository
    {
        private readonly Context _context;

        public ProductRepository(Context _context)
        {
            this._context = _context;
        }

		public Product GetById(int id, bool withCategory = false)
		{
			var query = _context.Products.AsQueryable();

			if (withCategory)
				query.Include(x => x.Category);

			return query.FirstOrDefault(x => x.Id == id);
		}

		public List<Product> GetAll(int page = 0, int pageSize = 20)
		{
			return _context.Products.Skip(page * pageSize).Take(pageSize).ToList();
		}

        public void Add(ProductCreateRequest productCreateRequest)
        {
            var category = _context.Categories.FirstOrDefault(b => b.Id == productCreateRequest.CategoryId);
            if (category is null) throw new System.Exception("Bad Request");

            Product product = new Product();
            product.Name = productCreateRequest.Name;
            product.Price = productCreateRequest.Price;
            product.CategoryId = productCreateRequest.CategoryId;

            _context.Products.Add(product);
            _context.SaveChanges();
        }

        public void Update(int id, ProductUpdateRequest productUpdateRequest)
        {
            var product = _context.Products.FirstOrDefault(x => x.Id == id);
            var category = _context.Categories.FirstOrDefault(b => b.Id == productUpdateRequest.CategoryId);

            if (product is null) throw new System.Exception("Not Found");
            if (category is null) throw new System.Exception("Bad Request");

            product.Name = productUpdateRequest.Name;
            product.Price = productUpdateRequest.Price;
            product.CategoryId = productUpdateRequest.CategoryId;

            _context.SaveChanges();
        }

        public void Delete(int id)
        {
            var p = _context.Products.FirstOrDefault(x => x.Id == id);

            if (p is null) throw new System.Exception("Not Found");

            _context.Products.Remove(p);

            _context.SaveChanges();
        }

        public List<Product> Search(string name, int? categoryId, double? minPrice)
        {
            var query = _context.Products.AsQueryable();

            if (!string.IsNullOrWhiteSpace(name))
                query.Where(x => x.Name.Contains(name));

            if (categoryId.HasValue)
                query.Where(x => x.CategoryId == categoryId);

            if (minPrice.HasValue)
                query.Where(x => x.Price > minPrice);

            return query.ToList();
        }

        
    }
}
