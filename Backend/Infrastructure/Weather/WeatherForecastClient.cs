using System.Net;
using Config;
using Domain.Weather;
using Domain.Weather.Models;
using Infrastructure.Weather.Responses;
using Microsoft.Extensions.Options;
using Newtonsoft.Json;

namespace Infrastructure.Weather;

public class WeatherForecastClient : IWeatherForecastClient
{
    public WeatherForecastClient(HttpClient httpClient, IOptions<ApplicationConfiguration> configuration)
    {
        _httpClient = httpClient;
        _configuration = configuration.Value;
    }

    private HttpClient _httpClient { get; }
    private ApplicationConfiguration _configuration { get; }

    public async Task<IEnumerable<WeatherForecast>?> GetForecastByCity(string city)
    {
        using (_httpClient)
        {
            var response =
                await _httpClient.GetAsync($"?q={city}&units=metric&appid={_configuration.OpenWeatherMapKey}");

            if (response.StatusCode != HttpStatusCode.OK) return null;

            return await ToDomainModel(response);
        }
    }

    public async Task<IEnumerable<WeatherForecast>?> GetForecastByCoordinates(string latitude, string longitude)
    {
        using (_httpClient)
        {
            var response =
                await _httpClient.GetAsync($"?lat={latitude}&lon={longitude}&units=metric&appid={_configuration.OpenWeatherMapKey}");

            if (response.StatusCode != HttpStatusCode.OK) return null;

            return await ToDomainModel(response);
        }
    }

    private async Task<IEnumerable<WeatherForecast>> ToDomainModel(HttpResponseMessage response)
    {
        var casted =
            JsonConvert.DeserializeObject<WeatherForecastResponse>(await response.Content.ReadAsStringAsync())!;

        return casted.WeatherStatusList.Select(w => new WeatherForecast
        {
            City = casted.CityResponse.Name,
            Date = TimeSpan.FromSeconds(long.Parse(w.TimeSpan)),
            Humidity = w.Statistic.Humidity,
            Temperature = w.Statistic.Temperature,
            CloudStatus = w.Status.First().CloudStatus,
            Pressure = w.Statistic.Pressure,
            WindSpeed = w.WindStatus.Speed
        });
    }
}