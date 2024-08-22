using Domain.Weather.Models;

namespace Domain.Weather;

public interface IWeatherForecastClient
{
    Task<IEnumerable<WeatherForecast>?> GetForecastByCity(string city);
    Task<IEnumerable<WeatherForecast>?> GetForecastByCoordinates(string latitude, string longitude);
}