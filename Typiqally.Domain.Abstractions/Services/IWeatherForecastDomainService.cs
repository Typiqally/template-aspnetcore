using System.Collections.Generic;
using System.Threading.Tasks;
using Typiqally.Domain.Abstractions.Models;

namespace Typiqally.Domain.Abstractions.Services
{
    public interface IWeatherForecastDomainService
    {
        Task<IEnumerable<WeatherForecast>> GetLatestForecastsAsync();
    }
}