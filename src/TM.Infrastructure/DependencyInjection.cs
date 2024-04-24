using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using TM.Infrastructure.Persistance;

namespace TM.Infrastructure
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddInfrastructure(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<TradeManagementDbContext>
                (options => options.
                            UseSqlServer(configuration.GetConnectionString("SqlServer")));

            return services;
        }
    }
}
