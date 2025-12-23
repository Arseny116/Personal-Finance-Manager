using Microsoft.EntityFrameworkCore;
using Users.Domain.DTOs;
using Users.Domain.Entities;
using Users.Domain.Interface;

namespace Users.Infrastructure.Repositories
{
    public class QueriesUser : IQueriesUser
    {
        private readonly UserDbContext _context;
        public QueriesUser(UserDbContext context)
        {
            _context = context;
        }

        public async Task<List<UserDTO>> GetAllUsers()
        {
            return await _context.Users
                .AsNoTracking()
                .Select(x => new UserDTO
                {
                    FirstName = x.FirstName,
                    LastName = x.LastName,
                    Email = x.Email
                }
                )
                .ToListAsync();
        }

        public async Task<UserDTO> GetUserById(Guid Id)
        {
            return await _context.Users
                .AsNoTracking()
                .Where(x => x.Id == Id)
                .Select(x => new UserDTO
                {
                    FirstName = x.FirstName,
                    LastName = x.LastName,
                    Email = x.Email
                }
                )
                .FirstOrDefaultAsync();
        }
    }
}
