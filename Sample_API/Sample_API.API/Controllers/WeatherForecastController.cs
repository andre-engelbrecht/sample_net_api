using Microsoft.AspNetCore.Mvc;
using Sample_API.Core.Models;
using Sample_API.Core.Services;

namespace Sample_API.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class WeatherForecastController : ControllerBase
    {
        private WeatherForecastService weatherForecastService;

        public WeatherForecastController(WeatherForecastService weatherForecastService)
        {
            this.weatherForecastService = weatherForecastService;   
        }

        [HttpGet(Name = "GetWeatherForecast")]
        public IEnumerable<WeatherForecast> Get()
        {
            return weatherForecastService.GetWeatherForecast();
        }

        [HttpGet("TestUpdate8")]
        public string TestUpdate()
        {
            return weatherForecastService.TestUpdate();
        }
    }
}