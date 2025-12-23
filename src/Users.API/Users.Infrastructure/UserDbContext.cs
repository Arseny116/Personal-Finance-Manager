using Microsoft.EntityFrameworkCore;
using Users.Infrastructure.DbModels;


namespace Users.Infrastructure
{
    public class UserDbContext : DbContext
    {

        public UserDbContext(DbContextOptions<UserDbContext> options) : base(options)
        {

        }

        public DbSet<UserDbModel> Users { get; set; }
    }

   
}
