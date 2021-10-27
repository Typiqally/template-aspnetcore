using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Typiqally.Domain.Abstractions.Models;
using Typiqally.Domain.Abstractions.Services;
using Typiqally.Persistence.Abstractions.Repositories;

namespace Typiqally.Domain.Services
{
    public class WeatherForecastDomainService : IWeatherForecastDomainService
    {
        private readonly IMapper _mapper;
        private readonly IWeatherForecastRepository _repository;

        public WeatherForecastDomainService(IMapper mapper, IWeatherForecastRepository repository)
        {
            _mapper = mapper;
            _repository = repository;
        }

        public async Task<IEnumerable<WeatherForecast>> GetLatestForecastsAsync()
        {
            var latestForecasts = await _repository.ToListAsync(
                null,
                forecasts => forecasts.OrderByDescending(x => x.Date),
                null,
                null,
                5
            );

            return _mapper.Map<IEnumerable<WeatherForecast>>(latestForecasts);
        }
    }
}