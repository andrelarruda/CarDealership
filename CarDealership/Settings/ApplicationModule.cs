using CarDealership.Data;
using CarDealership.Repositories;
using CarDealership.Services;
using Microsoft.EntityFrameworkCore;

namespace CarDealership.Settings
{
    public static class ApplicationModule
    {
        public static IServiceCollection AddApplication(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext(configuration);
            services.AddAutoMapper();
            services.AddServices();
            services.AddRepositories();
            services.AddControllersWithViews();
            return services;
        }

        public static IServiceCollection AddDbContext(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<CarDealershipContext>(options =>
            {
                options.UseSqlServer(configuration.GetConnectionString("CarDealershipConnection"));
            });
            return services;
        }

        public static IServiceCollection AddServices(this IServiceCollection services)
        {
            services.AddScoped<IFabricanteService, FabricanteService>();
            return services;
        }

        public static IServiceCollection AddRepositories(this IServiceCollection services)
        {
            services.AddScoped<IFabricanteRepository, FabricanteRepository>();
            return services;
        }

        public static IServiceCollection AddAutoMapper(this IServiceCollection services)
        {
            services.AddAutoMapper(typeof(MapperConfig));
            return services;
        }
    }
}
