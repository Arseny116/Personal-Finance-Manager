using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Users.Domain.Interface;


namespace Users.Infrastructure
{
    public class UserDbContext : DbContext
    {

        public UserDbContext(DbContextOptions<UserDbContext> options) : base(options)
        {

        }

        public DbSet<UserDbContext> Users { get; set; }
    }

   
}
