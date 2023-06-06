using System.Collections.Generic;
using WebApplication1.Models.Entity;
using WebApplication1.Models.Requests;
using WebApplication1.Models;
using System.Linq;
using WebApplication1.Interfaces;

namespace WebApplication1.Repositories
{
    public class CategoryRepository : ICategoryRepository
    {
        private readonly Context _context;

        public CategoryRepository(Context _context)
        {
            this._context = _context;
        }

        public Category GetById(int id)
        {
            return _context.Categories.FirstOrDefault(x => x.Id == id);
        }

        public List<Category> GetAll()
        {
            return _context.Categories.ToList();
        }

        public void Add(CategoryCreateRequest categoryCreateRequest)
        {
            Category category = new Category();

            category.Name = categoryCreateRequest.Name;
            category.IsActive = categoryCreateRequest.IsActive;

            _context.Categories.Add(category);
            _context.SaveChanges();
        }

        public void Update(int id, CategoryUpdateRequest UpdateRequest)
        {
            var category = _context.Categories.FirstOrDefault(x => x.Id == id);

            if (category is null) throw new System.Exception("Not Found");

            category.Name = UpdateRequest.Name;
            category.IsActive = UpdateRequest.IsActive;

            _context.SaveChanges();
        }

        public void Delete(int id)
        {
            var category = _context.Categories.FirstOrDefault(x => x.Id == id);

            if (category is null) throw new System.Exception("Not Found");

            category.IsActive = false;

            _context.SaveChanges();
        }

        public List<Category> Search(string name)
        {
            var query = _context.Categories.AsQueryable();

            if (!string.IsNullOrWhiteSpace(name))
                query.Where(x => x.Name.Contains(name));

            return query.ToList();
        }
    }
}
