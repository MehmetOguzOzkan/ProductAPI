using System.Collections.Generic;
using WebApplication1.Models.Entity;
using WebApplication1.Models.Requests;

namespace WebApplication1.Interfaces
{
    public interface IOrderRepository
    {
        public Order GetById(int id, bool withUser = false);

        public List<Order> GetByUserId(int userId, int page = 0, int pageSize = 10);

        public void Add(OrderCreateRequest orderCreateRequest);

        public void Update(int id, OrderUpdateRequest orderUpdateRequest);

        public void Delete(int id);

        public List<Order> Search(int? userId);
    }
}
