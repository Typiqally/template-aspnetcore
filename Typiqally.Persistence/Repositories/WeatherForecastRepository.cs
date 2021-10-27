using Typiqally.Persistence.Abstractions.Entities;
using Typiqally.Persistence.Abstractions.Repositories;

namespace Typiqally.Persistence.Repositories
{
	public class WeatherForecastRepository : EntityFrameworkCoreRepository<WeatherForecastEntity, ApplicationDbContext>, IWeatherForecastRepository
	{
		public WeatherForecastRepository(ApplicationDbContext context) : base(context)
		{
		}
	}
}