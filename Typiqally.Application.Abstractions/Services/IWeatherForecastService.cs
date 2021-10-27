using System.Collections.Generic;
using System.Threading.Tasks;
using Typiqally.Application.Abstractions.Dtos;

namespace Typiqally.Application.Abstractions.Services
{
    public interface IWeatherForecastService
    {
        Task<IEnumerable<WeatherForecastDto>> GetLatestForecastsAsync();
    }
}