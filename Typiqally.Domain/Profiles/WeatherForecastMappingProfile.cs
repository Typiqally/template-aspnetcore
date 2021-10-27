using AutoMapper;
using Typiqally.Domain.Abstractions.Models;
using Typiqally.Persistence.Abstractions.Entities;

namespace Typiqally.Domain.Profiles
{
    public class WeatherForecastMappingProfile : Profile
    {
        public WeatherForecastMappingProfile()
        {
            CreateMap<WeatherForecast, WeatherForecastEntity>();
            CreateMap<WeatherForecastEntity, WeatherForecast>();
        }
    }
}