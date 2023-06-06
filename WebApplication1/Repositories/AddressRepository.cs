using System.Collections.Generic;
using WebApplication1.Models.Entity;
using WebApplication1.Models.Requests;
using WebApplication1.Models;
using System.Linq;
using WebApplication1.Interfaces;

namespace WebApplication1.Repositories
{
    public class AddressRepository : IAddressRepository
    {
        private readonly Context _context;

        public AddressRepository(Context _context)
        {
            this._context = _context;
        }

        public Address GetById(int id)
        {
            return _context.Addresses.FirstOrDefault(b => b.Id == id);
        }

        public List<Address> GetAll(int page = 0, int pageSize = 20)
        {
            return _context.Addresses.Skip(page * pageSize).Take(pageSize).ToList();
        }

        public void Add(AddressCreateRequest addressCreateRequest)
        {
            var user = _context.Users.FirstOrDefault(b=>b.Id==addressCreateRequest.UserId);

            if (user is null) throw new System.Exception("Bad Request");

            Address address = new Address();
            address.UserId=addressCreateRequest.UserId;
            address.City=addressCreateRequest.City;
            address.Title=addressCreateRequest.Title;
            address.Text=addressCreateRequest.Text;

            _context.Addresses.Add(address);
            _context.SaveChanges();
        }

        public void Update(int id, AddressUpdateRequest addressUpdateRequest)
        {
            var address = _context.Addresses.FirstOrDefault(x => x.Id == id);

            if (address is null) throw new System.Exception("Not Found");

            address.City = addressUpdateRequest.City;
            address.Title = addressUpdateRequest.Title;
            address.Text = addressUpdateRequest.Text;

            _context.SaveChanges();
        }

        public void Delete(int id)
        {
            var address = _context.Addresses.FirstOrDefault(x => x.Id == id);

            if (address is null) throw new System.Exception("Not Found");

            _context.Addresses.Remove(address);

            _context.SaveChanges();
        }

        public List<Address> Search(int? userId, string city)
        {
            var query = _context.Addresses.AsQueryable();

            if (!string.IsNullOrWhiteSpace(city))
                query.Where(x => x.City.Contains(city));

            if (userId.HasValue)
                query.Where(x => x.UserId == userId);

            return query.ToList();
        }
    }
}
