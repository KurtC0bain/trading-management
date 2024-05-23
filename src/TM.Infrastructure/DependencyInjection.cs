using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using TM.Application.Common.Interfaces;
using TM.Domain.Entities;
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
                .AddEntityFrameworkStores<TradeManagementDbContext>();


            services.AddTransient<IRepositoryBase<Trade>, TradesRepository>();

            return services;
        }
    }
}
