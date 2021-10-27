using AutoMapper;
using Typiqally.Application.Abstractions.Dtos;
using Typiqally.Domain.Abstractions.Models;

namespace Typiqally.Application.Profiles
{
    public class WeatherForecastDtoMappingProfile : Profile
    {
        public WeatherForecastDtoMappingProfile()
        {
            CreateMap<WeatherForecastDto, WeatherForecast>();
            CreateMap<WeatherForecast, WeatherForecastDto>();
        }
    }
}