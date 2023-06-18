using Budgy_Server.Infrastructure.Data;
using Budgy_Server.Infrastructure.Data.Common;
using Budgy_Server.Infrastructure.Data.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace Budgy_Server.Extensions
{
    public static class BudgyServiceCollectionExtenstions
    {
        public static IServiceCollection AddApplicationServices(this IServiceCollection services)
        {
            return services;
        }

        public static IServiceCollection AddDbContext(this IServiceCollection services, IConfiguration configuration) 
        {
            var connectionString = configuration.GetConnectionString("DefaultConnection");
            services.AddDbContext<ApplicationDbContext>(options =>
                options.UseSqlServer(connectionString)
                .UseLazyLoadingProxies());

            services.AddScoped<IRepository, Repository>();

            return services;
        }

        public static void ConfigureCors(this IServiceCollection services)
        {
            services.AddCors(options =>
            {
                options.AddPolicy("all", opt =>
                {
                    opt.AllowAnyOrigin();
                    opt.AllowAnyMethod();
                    opt.AllowAnyHeader();
                });
            });
        }

        public static IServiceCollection AddIdentity(this IServiceCollection services)
        {
            services.AddIdentity<AppUser, IdentityRole>(IdentityOptionsProvider.GetIdentityOptions)
                .AddEntityFrameworkStores<ApplicationDbContext>()
                .AddDefaultTokenProviders();

            return services;
        }
    }
}
