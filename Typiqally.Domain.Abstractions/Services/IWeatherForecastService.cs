using System.Collections.Generic;
using System.Threading.Tasks;
using Typiqally.Domain.Abstractions.Models;

namespace Typiqally.Domain.Abstractions.Services
{
	public interface IWeatherForecastService
	{
		Task<IEnumerable<WeatherForecast>> GetLatestForecastsAsync();
	}
}