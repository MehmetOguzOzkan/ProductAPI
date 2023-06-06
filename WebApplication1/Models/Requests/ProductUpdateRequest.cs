﻿using System.ComponentModel.DataAnnotations;

namespace WebApplication1.Models.Requests
{
    public class ProductUpdateRequest
    {
        [MaxLength(100)]
        public string Name { get; set; }

        public double Price { get; set; }

        public int CategoryId { get; set; }
    }
}
