using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace WebApplication1.Models.Entity
{
    [Table("Users")]
    public class User : BaseEntity<int>
    {
        public string Name { get; set; }

        public List<Order> Orders { get; set; }

        public UserType Type { get; set; }

        public List<Address> Addresses { get; set; }

        public GenderType? Gender { get; set; }

    }

    public enum GenderType :byte
    {
        Male = 1, Female, Other
    }

    public enum UserType : byte
    {
        Customer = 1,
        Seller ,
        Admin
    }
}
