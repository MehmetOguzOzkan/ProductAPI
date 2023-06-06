using System.Collections.Generic;
using WebApplication1.Models.Entity;
using WebApplication1.Models.Requests;
using WebApplication1.Models;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using WebApplication1.Interfaces;

namespace WebApplication1.Repositories
{
    public class OrderRepository : IOrderRepository
    {
        private readonly Context _context;

        public OrderRepository(Context _context)
        {
            this._context = _context;
        }

        public Order GetById(int id, bool withUser = false)
        {
            var query = _context.Orders.AsQueryable();

            if (withUser)
                query.Include(x => x.User);

            return query.FirstOrDefault(x => x.Id == id);
        }

        public List<Order> GetByUserId(int userId, int page = 0, int pageSize=10)
        {
            return _context.Orders.Where(b=>b.UserId==userId).Skip(page * pageSize).Take(pageSize).ToList();
        }

        public void Add(OrderCreateRequest orderCreateRequest)
        {
            var user = _context.Users.FirstOrDefault(b => b.Id==orderCreateRequest.UserId);
            var address = _context.Addresses.FirstOrDefault(b => b.Id == orderCreateRequest.AddressId);

            if (user is null) throw new System.Exception("Bad Request");
            if (address is null) throw new System.Exception("Bad Request");

            Order order = new Order();
            order.UserId = orderCreateRequest.UserId;
            order.AddressId = orderCreateRequest.AddressId;
            order.Items = orderCreateRequest.Items;
            order.Note = orderCreateRequest.Note;

            _context.Orders.Add(order);
            _context.SaveChanges();
        }

        public void Update(int id, OrderUpdateRequest orderUpdateRequest)
        {
            var order = _context.Orders.FirstOrDefault(b => b.Id == id);

            if (order is null) throw new System.Exception("Not Found");

            var address = _context.Addresses.FirstOrDefault(b => b.Id == orderUpdateRequest.AddressId);

            if (address is null) throw new System.Exception("Bad Request");

            order.AddressId = orderUpdateRequest.AddressId;
            order.Items = orderUpdateRequest.Items;
            order.Note = orderUpdateRequest.Note;

            _context.SaveChanges();
        }

        public void Delete(int id)
        {
            var order = _context.Orders.FirstOrDefault(b => b.Id == id);

            if (order is null) throw new System.Exception("Not Found");

            _context.Orders.Remove(order);

            _context.SaveChanges();
        }

        public List<Order> Search(int? userId)
        {
            var query = _context.Orders.AsQueryable();

            if (userId.HasValue)
                query.Where(x => x.UserId == userId);


            return query.ToList();
        }
    }
}
