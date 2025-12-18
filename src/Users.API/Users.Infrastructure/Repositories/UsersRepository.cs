using Users.Domain.Entities;
using Users.Domain.Interface;
using Users.Infrastructure.DbModels;

namespace Users.Infrastructure.Repositories
{
    public class UsersRepository : IUsersRepository
    {
        private  readonly UserDbContext _userDbContext;
        public UsersRepository(UserDbContext userDbContext) 
        {
            _userDbContext = userDbContext;
        }

        public async Task CreateUser(User user)
        {
            await  _userDbContext.Users
                .AddAsync(new UserDbModel
                {
                    Id        = user.Id,
                    FirstName = user.FirstName,
                    LastName  = user.LastName,
                    Password  = user.Password,
                    Email     = user.Email,
                    IsActive  = user.IsActive,
                    UpdatedAt = user.UpdatedAt,
                    CreatedAt = user.CreatedAt
                });
        }
    }
}
