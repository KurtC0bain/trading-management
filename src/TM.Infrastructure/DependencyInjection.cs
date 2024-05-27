using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using TM.Application.Common.Interfaces;
using TM.Domain.Entities;
using TM.Infrastructure.Binance.API.Services;
using TM.Infrastructure.Persistance;
using TM.Infrastructure.Persistance.Repositories;

namespace TM.Infrastructure
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddInfrastructure(this IServiceCollection services, IConfiguration configuration)
        {

            services.AddTransient<ITradingManagementDbContext, TradeManagementDbContext>();

            services.AddDbContext<TradeManagementDbContext>
                (options => options.
                            UseSqlServer(configuration.GetConnectionString("SqlServer")));

            services.AddIdentityApiEndpoints<IdentityUser>()
                .AddRoles<IdentityRole>()
                .AddEntityFrameworkStores<TradeManagementDbContext>();
            services.Configure<IdentityOptions>(options =>
            {
                options.Password.RequireDigit = true;
                options.Password.RequireLowercase = true;
                options.Password.RequireNonAlphanumeric = true;
                options.Password.RequireUppercase = true;
                options.Password.RequiredLength = 6;
            });


            services.AddTransient<IRepositoryBase<Trade>, TradesRepository>();
            services.AddTransient<IRepositoryBase<Pair>, PairsRepository>();
            services.AddTransient<IRepositoryBase<Factor>, FactorsRepository>();
            services.AddTransient<IRepositoryBase<Setup>, SetupsRepository>();

            services.AddTransient<IAssetsService, AssetsService>();

            return services;
        }
    }
}
