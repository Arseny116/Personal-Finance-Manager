using Users.Domain.Entities;

namespace Users.Domain.Interface
{
    public interface IRepositoryUsers
    {
        public Task<List<User>> GetAllUsers();
        public Task<User> GetUserById(Guid id);
    }
}
