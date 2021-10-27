using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Typiqally.Application.Abstractions.Services;
using Typiqally.Application.Profiles;
using Typiqally.Application.Services;
using Typiqally.Persistence.IoC;

namespace Typiqally.Application.IoC
{
    public static class ApplicationServiceCollectionExtensions
    {
        public static IServiceCollection AddApplication(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddPersistence(configuration);
            
            services.AddAutoMapper(config =>
            {
                config.AddProfile<WeatherForecastDtoMappingProfile>();
            });

            services.AddScoped<IWeatherForecastService, WeatherForecastService>();

            return services;
        }
    }
}