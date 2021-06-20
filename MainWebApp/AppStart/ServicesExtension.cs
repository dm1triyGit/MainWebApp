using BLL.Interfaces;
using BLL.Services;
using DAL.Interfaces;
using DAL.Repositories;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;
using WebUI.Mapping;

namespace WebUI.AppStart
{
    public static class ServicesExtension
    {
        private static readonly string RedirectPath = "/Account/Login";

        public static void RegisterServices(this IServiceCollection services)
        {
            services.AddScoped<IUserRepository, UserRepository>();
            services.AddScoped<IUserService, UserService>();
        }

        public static void AddCustomAuthentication(this IServiceCollection services)
        {
            services.AddAuthentication(CookieAuthenticationDefaults.AuthenticationScheme)
                .AddCookie(options =>
                {
                    options.LoginPath = new PathString(RedirectPath);
                    //options.AccessDeniedPath = new PathString(RedirectPath);
                });
        }

        public static void RegisterMapper(this IServiceCollection services)
        {
            var mapper = MapperCreater.CreateMapperConfig();
            services.AddSingleton(mapper);
        }
    }
}
