using Application.Aplic;
using Application.Interfaces;
using Application.Services;
using Domain.Interfaces;
using Domain.Services;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Persistense.Context;

namespace Persistense
{
    public static class ServiceExtensions
    {
        public static void ConfigurePersistenseApp(this IServiceCollection services, IConfiguration configuration)
        {
            var connectionString = configuration.GetConnectionString("DefaultConnection");

            services.AddDbContext<AppDbContext>(opt =>
                opt.UseMySql(connectionString, ServerVersion.AutoDetect(connectionString),
                    b => b.MigrationsAssembly("EnergyCom")));

            // Repositories
            services.AddScoped<IUnitOfWork, UnitOfWork>();
            services.AddScoped<IUcRepository, UcRepository>();
            services.AddScoped<IConsumidorRepository, ConsumidorRepository>();

            // Domain Services
            services.AddScoped<IUcService, UcService>();
            services.AddScoped<IConsumidorService, ConsumidorService>();

            // Application Services
            services.AddScoped<IAplicUc, AplicUc>();
            services.AddScoped<IAplicConsumidor, AplicConsumidor>();
        }
    }
}
