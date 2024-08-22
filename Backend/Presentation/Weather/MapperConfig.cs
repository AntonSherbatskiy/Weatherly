using Domain.Weather.Models;
using Mapster;
using Presentation.Weather.Contracts;

namespace Presentation.Weather;

public class MapperConfig : IRegister
{
    public void Register(TypeAdapterConfig config)
    {
        config.NewConfig<WeatherForecast, WeatherForecastResponse>()
            .Map(response => response.Date, domain => domain.Date.TotalSeconds);
    }
}