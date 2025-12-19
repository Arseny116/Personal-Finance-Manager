
using Users.Domain.ValueObject;
namespace Users.Domain.DTOs
{
    public class UserDTO()
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public Email Email { get; set; }
    }
}
