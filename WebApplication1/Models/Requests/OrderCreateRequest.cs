using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using WebApplication1.Models.Entity;

namespace WebApplication1.Models.Requests
{
    public class OrderCreateRequest
    {
        public int UserId { get; set; }

        public List<OrderItem> Items { get; set; }

        [MaxLength(500)]
        public string Note { get; set; }

        public int AddressId { get; set; }
    }
}
