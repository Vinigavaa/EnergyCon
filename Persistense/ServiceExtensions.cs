using Domain.Interfaces;
using EnergyCom.Context;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Persistense
{
    public static class ServiceExtensions
    {
        public static void ConfigurePersistenseApp(this IServiceCollection services, IConfiguration configuration)
        {
            var connectionString = configuration.GetConnectionString("DefaultConnection");

            services.AddDbContext<AppDbContext>(opt =>
                opt.UseMySql(connectionString, ServerVersion.AutoDetect(connectionString)));

            services.AddScoped<IUnitOfWork, UnitOfWork>();

            services.AddScoped<IUcRepository, UcRepository>();
        }
    }
}
