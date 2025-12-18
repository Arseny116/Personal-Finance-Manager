using Users.Domain.Entities;

namespace Users.Domain.Interface
{
    public interface IUsersRepository
    {
        Task CreateUser(User user);
    }
}
