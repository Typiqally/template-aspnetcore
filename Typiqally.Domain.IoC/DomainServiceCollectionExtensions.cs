using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Typiqally.Domain.Abstractions.Services;
using Typiqally.Domain.Profiles;
using Typiqally.Domain.Services;
using Typiqally.Persistence.IoC;

namespace Typiqally.Domain.IoC
{
    public static class DomainServiceCollectionExtensions
    {
        public static IServiceCollection AddDomain(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddPersistence(configuration);

            services.AddScoped<IWeatherForecastService, WeatherForecastService>();
            
            // AutoMapper profiles
            services.AddAutoMapper(config =>
            {
                config.AddProfile<WeatherForecastMappingProfile>();
            });

            return services;
        }
    }
}