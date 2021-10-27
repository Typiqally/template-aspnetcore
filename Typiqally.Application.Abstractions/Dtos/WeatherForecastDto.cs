using System;

namespace Typiqally.Application.Abstractions.Dtos
{
    public class WeatherForecastDto
    {
        public int TemperatureC { get; set; }

        public int TemperatureF { get; set; }

        public string Summary { get; set; }

        public DateTime Date { get; set; }
    }
}