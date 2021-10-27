using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using Typiqally.Application.Abstractions.Dtos;
using Typiqally.Application.Abstractions.Services;
using Typiqally.Domain.Abstractions.Services;

namespace Typiqally.Application.Services
{
    public class WeatherForecastService : IWeatherForecastService
    {
        private readonly IMapper _mapper;
        private readonly IWeatherForecastDomainService _service;

        public WeatherForecastService(IMapper mapper, IWeatherForecastDomainService service)
        {
            _mapper = mapper;
            _service = service;
        }

        public async Task<IEnumerable<WeatherForecastDto>> GetLatestForecastsAsync()
        {
            var latestForecasts = await _service.GetLatestForecastsAsync();
            return _mapper.Map<IEnumerable<WeatherForecastDto>>(latestForecasts);
        }
    }
}