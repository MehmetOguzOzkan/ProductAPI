using System.ComponentModel.DataAnnotations.Schema;
using WebApplication1.Models.Entity;

namespace WebApplication1.Models.Requests
{
    public class AddressCreateRequest
    {
        public int UserId { get; set; }

        public string City { get; set; }

        public string Title { get; set; }

        public string Text { get; set; }
    }
}
