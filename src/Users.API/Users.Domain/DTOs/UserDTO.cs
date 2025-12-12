
using Users.Domain.ValueObject;
namespace Users.Domain.DTOs
{
    public class UserDTO(string FirstName, string LastName, Email Email)
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public Email Email { get; set; }
    }
}
