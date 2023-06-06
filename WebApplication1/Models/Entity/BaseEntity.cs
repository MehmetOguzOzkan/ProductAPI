using System;
using System.ComponentModel.DataAnnotations;

namespace WebApplication1.Models.Entity
{
    public abstract class BaseEntity<T>
    {
        [Key]
        public T Id { get; set; }

        public DateTime CreatedAt { get; set; } = DateTime.Now;
    }
}
