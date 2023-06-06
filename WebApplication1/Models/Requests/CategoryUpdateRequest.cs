using System.ComponentModel.DataAnnotations;

namespace WebApplication1.Models.Requests
{
    public class CategoryUpdateRequest
    {
        [MaxLength(100)]
        public string Name { get; set; }

        public bool IsActive { get; set; }
    }
}
