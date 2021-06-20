using DAL;
using DAL.Entities;
using Microsoft.AspNetCore.Builder;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System.Linq;

namespace WebUI.AppStart
{
    public static class DBContextExtension
    {
        private static readonly string AssemblyName = "WebUI";

        private static readonly string ConnectionStringName = "DefaultConnection";

        private static readonly string UserRoleName = "UserRole";
        private static readonly string AdminRoleName = "AdminRole";

        public static void AddCustomDbContext(this IServiceCollection services, IConfiguration configuration)
        {
            string connection = configuration.GetConnectionString(ConnectionStringName);

            services.AddDbContext<MainContext>(options =>
                options.UseSqlServer(connection, b => b.MigrationsAssembly(AssemblyName)));
        }

        public static void InitialDatabase(this IApplicationBuilder app)
        {
            using (var scope = app.ApplicationServices.CreateScope())
            {
                var context = scope.ServiceProvider.GetRequiredService<MainContext>();

                if (!context.Roles.Any() && !context.Users.Any())
                {
                    CreateRolesAndUsers(context);
                }
            }
        }

        private static void CreateRolesAndUsers(MainContext context)
        {
            var roleAdmin = new Role { Name = AdminRoleName };
            var roleUser = new Role { Name = UserRoleName };

            var defaultAdmin = new User
            {
                Login = "admin",
                Password = "qweasd",
                Role = roleAdmin
            };

            context.Users.Add(defaultAdmin);
            context.Roles.Add(roleUser);

            context.SaveChanges();
        }
    }
}
