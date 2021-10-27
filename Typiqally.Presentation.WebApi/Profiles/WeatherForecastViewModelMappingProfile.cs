using AutoMapper;
using Typiqally.Domain.Abstractions.Models;
using Typiqally.Presentation.WebApi.ViewModels;

namespace Typiqally.Presentation.WebApi.Profiles
{
	public class WeatherForecastViewModelMappingProfile : Profile
	{
		public WeatherForecastViewModelMappingProfile()
		{
			CreateMap<WeatherForecastViewModel, WeatherForecast>();
			CreateMap<WeatherForecast, WeatherForecastViewModel>();
		}
	}
}