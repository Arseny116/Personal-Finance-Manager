using Users.Domain.DTOs;

namespace Users.Domain.Interface
{
    public interface IQueriesUser
    {
        Task<List<UserDTO>> GetAllUsers();
        Task<UserDTO> GetUserById(Guid id);
    }
}
