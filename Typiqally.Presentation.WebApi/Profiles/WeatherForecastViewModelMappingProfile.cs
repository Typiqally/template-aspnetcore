using AutoMapper;
using Typiqally.Application.Abstractions.Dtos;
using Typiqally.Presentation.WebApi.ViewModels;

namespace Typiqally.Presentation.WebApi.Profiles
{
    public class WeatherForecastViewModelMappingProfile : Profile
    {
        public WeatherForecastViewModelMappingProfile()
        {
            CreateMap<WeatherForecastViewModel, WeatherForecastDto>();
            CreateMap<WeatherForecastDto, WeatherForecastViewModel>();
        }
    }
}