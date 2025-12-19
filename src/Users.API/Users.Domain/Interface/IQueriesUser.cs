using Users.Domain.Entities;

namespace Users.Domain.Interface
{
    public interface IQueriesUser
    {
        Task<List<User>> GetUsers();
        Task<User> GetUserById();
    }
}
