using Domain.Weather.Models;
using Infrastructure.Weather;
using Infrastructure.Weather.Responses;
using Mapster;

namespace Infrastructure.Configuration;

public class MapperConfiguration : IRegister
{
    public void Register(TypeAdapterConfig config)
    {
        config.NewConfig<WeatherForecastResponse, ICollection<WeatherForecast>>()
            .Map(dest => dest, response => response.WeatherStatusList
                .Select(c => new WeatherForecast
                {
                    City = response.CityResponse.Name,
                    Date = TimeSpan.FromSeconds(long.Parse(c.TimeSpan)),
                    Humidity = c.Statistic.Humidity,
                    Temperature = c.Statistic.Temperature,
                    CloudStatus = c.Status.First().CloudStatus,
                    Pressure = c.Statistic.Pressure,
                    WindSpeed = c.WindStatus.Speed
                }));
    }
}