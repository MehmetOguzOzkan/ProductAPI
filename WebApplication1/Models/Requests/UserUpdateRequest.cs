using WebApplication1.Models.Entity;

namespace WebApplication1.Models.Requests
{
    public class UserUpdateRequest
    {
        public string Name { get; set; }
        public UserType Type { get; set; }
        public GenderType? Gender { get; set; }
    }
}
