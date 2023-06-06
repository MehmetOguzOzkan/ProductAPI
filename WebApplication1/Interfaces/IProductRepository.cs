using System.Collections.Generic;
using WebApplication1.Models.Entity;
using WebApplication1.Models.Requests;

namespace WebApplication1.Interfaces
{
    public interface IProductRepository
    {
        public Product GetById(int id, bool withCategory = false);

        public List<Product> GetAll(int page, int pageSize);

        public void Add(ProductCreateRequest productCreateRequest);

        public void Update(int id, ProductUpdateRequest productUpdateRequest);

        public void Delete(int id);

        public List<Product> Search(string name, int? categoryId, double? minPrice);
    }
}
