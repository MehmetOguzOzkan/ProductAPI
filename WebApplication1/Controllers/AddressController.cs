using Microsoft.AspNetCore.Mvc;
using WebApplication1.Interfaces;

namespace WebApplication1.Controllers
{
    [Route("addresses")]
    public class AddressController : Controller
    {
        private readonly IAddressRepository addressRepository;

        public AddressController(IAddressRepository addressRepository)
        {
            this.addressRepository = addressRepository;
        }
    }
}
