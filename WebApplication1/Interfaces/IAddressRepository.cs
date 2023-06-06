using System.Collections.Generic;
using WebApplication1.Models.Entity;
using WebApplication1.Models.Requests;

namespace WebApplication1.Interfaces
{
    public interface IAddressRepository
    {
        public Address GetById(int id);

        public List<Address> GetAll(int page, int pageSize);

        public void Add(AddressCreateRequest addressCreateRequest);

        public void Update(int id, AddressUpdateRequest addressUpdateRequest);

        public void Delete(int id);

        public List<Address> Search(int? userId, string city);
    }
}
