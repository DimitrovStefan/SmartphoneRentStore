namespace SmartphoneRentStore.Extensions.DependencyInjection
{
    using Microsoft.AspNetCore.Identity;
    using Microsoft.EntityFrameworkCore;
    using SmartphoneRentStore.Core.Contracts;
    using SmartphoneRentStore.Core.Services;
    using SmartphoneRentStore.Infastructure.Data;
    using SmartphoneRentStore.Infrastructure.Data.Common;

    public static class ServiceCollectionExtension
    {
        public static IServiceCollection AddApplicationServices(this IServiceCollection services)
        {
            services.AddScoped<ISmartphoneService, SmartphoneService>();
            services.AddScoped<ISupplierService, SupplierService>();
            services.AddScoped<IStatisticService, StatisticService>();

            return services;
        }

        public static IServiceCollection AddApplicationDbContext(this IServiceCollection services, IConfiguration config)
        {
            var connectionString = config.GetConnectionString("DefaultConnection") ?? throw new InvalidOperationException("Connection string 'DefaultConnection' not found.");
            services.AddDbContext<SmartPhoneDbContext>(options =>
                options.UseSqlServer(connectionString));

            services.AddScoped<IRepository, Repository>();

            services.AddDatabaseDeveloperPageExceptionFilter();

            return services;

        }

        public static IServiceCollection AddApplicationidentity(this IServiceCollection services, IConfiguration config)
        {
            services.AddDefaultIdentity<IdentityUser>(options =>
            {
                options.SignIn.RequireConfirmedAccount = true;
                options.Password.RequireNonAlphanumeric = true;
                options.Password.RequireLowercase = true;
                options.Password.RequireDigit = true;
                options.Password.RequireUppercase = true;
            })
                    .AddEntityFrameworkStores<SmartPhoneDbContext>();

            return services; 

        }
    }
}
