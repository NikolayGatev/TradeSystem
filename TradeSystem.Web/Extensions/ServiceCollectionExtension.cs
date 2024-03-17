using Microsoft.EntityFrameworkCore;
using TradeSystem.Data.Models;
using TradeSystem.Data;
using TradeSystem.Data.Common;
using TradeSystem.Data.Repositories;

namespace Microsoft.Extensions.DependencyInjection
{
    public static class ServiceCollectionExtension
    {
        public static IServiceCollection AddApplicationServices(this IServiceCollection services)
        {
            return services;
        }

        public static IServiceCollection AddApplicationDbContext(this IServiceCollection services, IConfiguration config)
        {
            var connectionString =
                config.GetConnectionString("DefaultConnection") ?? throw new InvalidOperationException("Connection string 'DefaultConnection' not found.");
            services.AddDbContext<TradeSystemDbContext>(options =>
                options.UseSqlServer(connectionString));

            services.AddScoped(typeof(IDeletableEntityRepository<>), typeof(EfDeletableEntityRepository<>));
            services.AddScoped(typeof(IRepository<>), typeof(EfRepository<>));
            services.AddScoped<IDbQueryRunner, DbQueryRunner>();

            services.AddDatabaseDeveloperPageExceptionFilter();

            return services;
        }

        public static IServiceCollection AddApplicationIdentity(this IServiceCollection services, IConfiguration config) 
        {
            services.AddDefaultIdentity<ApplicationUser>(options =>
            {
                options.SignIn.RequireConfirmedAccount =
                    config.GetValue<bool>("Identity:SignIn:RequireConfirmedAccount");
                options.Password.RequireLowercase =
                    config.GetValue<bool>("Identity:Password:RequireLowercase");
                options.Password.RequireUppercase =
                    config.GetValue<bool>("Identity:Password:RequireUppercase");
                options.Password.RequireNonAlphanumeric =
                    config.GetValue<bool>("Identity:Password:RequireNonAlphanumeric");
                options.Password.RequiredLength =
                    config.GetValue<int>("Identity:Password:RequiredLength");
                options.Password.RequireDigit =
                    config.GetValue<bool>("Identity:Password:RequireDigit");
            })
               .AddEntityFrameworkStores<TradeSystemDbContext>();
            return services; 
        }

    }
}
