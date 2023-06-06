using System.Collections.Generic;
using WebApplication1.Models.Entity;
using WebApplication1.Models.Requests;

namespace WebApplication1.Interfaces
{
    public interface IUserRepository
    {
        public User GetById(int id);

        public List<User> GetAll(int page, int pageSize);

        public void Add(UserCreateRequest userCreateRequest);

        public void Update(int id, UserUpdateRequest userUpdateRequest);

        public void Delete(int id);

        public List<User> Search(string name, GenderType? gender, UserType? type);
    }
}
