using System;

namespace Typiqally.Persistence.Abstractions.Entities
{
	public class WeatherForecastEntity : Entity<int>
	{
		public int TemperatureC { get; set; }

		public string Summary { get; set; }

		public DateTime Date { get; set; }
	}
}