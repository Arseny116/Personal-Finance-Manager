using Microsoft.EntityFrameworkCore;
using Users.Application.Handlers;
using Users.Infrastructure;

namespace Users.API
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);





           builder.Services.AddDbContext<UserDbContext>(options => 
           {
               options.UseNpgsql(builder.Configuration.GetConnectionString("DefaultConnection"));
           });


            builder.Services.AddMediatR(cfg =>
            {
                cfg.RegisterServicesFromAssembly(typeof(GetUserHandler).Assembly);
            });

            builder.Services.AddControllers();
   
            builder.Services.AddOpenApi();

            var app = builder.Build();

       
            if (app.Environment.IsDevelopment())
            {
                app.MapOpenApi();
            }

            app.UseHttpsRedirection();

            app.UseAuthorization();


            app.MapControllers();

            app.Run();
        }
    }
}
