using Domain.Interfaces;
using Infraestructure.Database;
using Infraestructure.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Infraestructure
{
    public static class Installer
    {
        public static void InstallRepositories(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<SqlServerContext>(options => 
            {
                options.UseSqlServer(configuration.GetConnectionString("Default"), options => {});
            });

            services.AddScoped<IUserRepository,UserRepository>();
        }
    }
}