using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using WebApplication1.Interfaces;
using WebApplication1.Models;
using WebApplication1.Models.Entity;
using WebApplication1.Models.Requests;

namespace WebApplication1.Repositories
{
    public class UserRepository : IUserRepository
    {
        private readonly Context _context;

        public UserRepository(Context _context)
        {
            this._context = _context;
        }

        public User GetById(int id)
        {
            return _context.Users.FirstOrDefault(x => x.Id == id);
        }

        public List<User> GetAll(int page = 0, int pageSize = 10)
        {
            return _context.Users.Skip(page * pageSize).Take(pageSize).ToList();
        }

        public void Add(UserCreateRequest userCreateRequest)
        {
            User user = new User();
            user.Name = userCreateRequest.Name;
            user.Gender = userCreateRequest.Gender;
            user.Type = userCreateRequest.Type;

            _context.Users.Add(user);
            _context.SaveChanges();
        }

        public void Update(int id, UserUpdateRequest userUpdateRequest)
        {
            var user = _context.Users.FirstOrDefault(x => x.Id == id);

            if (user is null) throw new System.Exception("Not Found");

            user.Name = userUpdateRequest.Name;
            user.Gender = userUpdateRequest.Gender;
            user.Type = userUpdateRequest.Type;

            _context.SaveChanges();
        }

        public void Delete(int id)
        {
            var user = _context.Users.FirstOrDefault(x => x.Id == id);

            if (user is null) throw new System.Exception("Not Found");

            _context.Users.Remove(user);

            _context.SaveChanges();
        }

        public List<User> Search(string name, GenderType? gender, UserType? type)
        {
            var query = _context.Users.AsQueryable();

            if (!string.IsNullOrWhiteSpace(name))
                query.Where(x => x.Name.Contains(name));

            if (gender.HasValue)
                query.Where(x => x.Gender == gender);

            if (type.HasValue)
                query.Where(x => x.Type == type);

            return query.ToList();
        }

    }
}
