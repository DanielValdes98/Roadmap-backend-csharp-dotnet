using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]

    public class WeatherForecastController : ControllerBase
    {
        private static readonly string[] Summaries = new[]
        {
            "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
        };

        private readonly ILogger<WeatherForecastController> _logger;

        private static List<WeatherForecast> listWeatherForecast = new List<WeatherForecast>();

        public WeatherForecastController(ILogger<WeatherForecastController> logger)
        {
            _logger = logger;

            if (listWeatherForecast == null || !listWeatherForecast.Any())
            {
                listWeatherForecast = Enumerable.Range(1, 5).Select(index => new WeatherForecast
                {
                    Date = DateOnly.FromDateTime(DateTime.Now.AddDays(index)),
                    TemperatureC = Random.Shared.Next(-20, 55),
                    Summary = Summaries[Random.Shared.Next(Summaries.Length)]
                }).ToList();
            }
        }

        [HttpGet(Name = "GetWeatherForecast")]
        //[Route("GetWeatherForecast")]
        //[Route("GetWeatherForecast2")]
        //[Route("[action]")]
        public IEnumerable<WeatherForecast> Get()
        {
            _logger.LogInformation("Retornando la lista de Weather Forecast");
            return listWeatherForecast;
        }

        [HttpPost(Name = "PostWeatherForecast")]
        //[Route("PostWeatherForecast")]
        public ActionResult Post(WeatherForecast weatherForecast)
        {
            listWeatherForecast.Add(weatherForecast);
            return Ok();
        }

        [HttpDelete("{index}", Name = "DeleteWeatherForecast")]
        //[Route("DeleteWeatherForecast")]
        public ActionResult Delete([FromRoute] int index)
        {
            listWeatherForecast.RemoveAt(index);
            return Ok();
        }


    }
}
