using FluentValidation;
using MediatR;
using Microsoft.Extensions.DependencyInjection;
using TM.Application.Behaviour;
using TM.Application.Common.Models;
using TM.Application.MapperProfiles;
using TM.Application.Validation;

namespace TM.Application
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddApplication(this IServiceCollection services)
        {
            var assembly = typeof(DependencyInjection).Assembly;

            services.AddMediatR(configuration =>
            {
                configuration.RegisterServicesFromAssembly(assembly);

                configuration.AddOpenBehavior(typeof(ValidationBehaviour<,>));
            });

            services.AddValidatorsFromAssembly(assembly);

            services.AddAutoMapper(typeof(TradeProfile));   
            services.AddAutoMapper(typeof(AssetProfile));
            services.AddAutoMapper(typeof(PairsProfile));
            services.AddAutoMapper(typeof(FactorsProfile));

            return services;
        }
    }
}
