namespace WebApi.Controllers.Interface;

public interface IWeatherForecastController
{
    IEnumerable<WeatherForecast> Get();
    IEnumerable<WeatherForecast> Set(int temp);
}