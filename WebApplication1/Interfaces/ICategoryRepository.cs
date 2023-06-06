using System.Collections.Generic;
using WebApplication1.Models.Entity;
using WebApplication1.Models.Requests;

namespace WebApplication1.Interfaces
{
    public interface ICategoryRepository
    {
        public Category GetById(int id);

        public List<Category> GetAll();

        public void Add(CategoryCreateRequest categoryCreateRequest);

        public void Update(int id, CategoryUpdateRequest UpdateRequest);

        public void Delete(int id);

        public List<Category> Search(string name);
    }
}
