using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Typiqally.Domain.Abstractions.Services;
using Typiqally.Presentation.WebApi.ViewModels;

namespace Typiqally.Presentation.WebApi.Controllers
{
	[ApiController]
	[Route("[controller]")]
	public class WeatherForecastController : ControllerBase
	{
		private readonly IMapper _mapper;
		private readonly IWeatherForecastService _service;

		public WeatherForecastController(IMapper mapper, IWeatherForecastService service)
		{
			_mapper = mapper;
			_service = service;
		}

		[HttpGet]
		public async Task<ActionResult<IEnumerable<WeatherForecastViewModel>>> GetForecasts()
		{
			var forecasts = await _service.GetLatestForecastsAsync();
			var viewModels = _mapper.Map<IEnumerable<WeatherForecastViewModel>>(forecasts);
			return Ok(viewModels);
		}
	}
}