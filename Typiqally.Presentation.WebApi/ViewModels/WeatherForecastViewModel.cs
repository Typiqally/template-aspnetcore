using System;

namespace Typiqally.Presentation.WebApi.ViewModels
{
    public class WeatherForecastViewModel
    {
        public int TemperatureC { get; set; }

        public int TemperatureF { get; set; }

        public string Summary { get; set; }

        public DateTime Date { get; set; }
    }
}