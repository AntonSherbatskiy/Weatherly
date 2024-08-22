using Newtonsoft.Json;

namespace Infrastructure.Weather.Responses;

public class WeatherForecastResponse
{
    [JsonProperty("cod")] public string Code { get; set; }

    [JsonProperty("list")] public IEnumerable<WeatherComponent> WeatherStatusList { get; set; }

    [JsonProperty("city")] public CityResponse CityResponse { get; set; }
}

public class WeatherComponent
{
    [JsonProperty("dt")] public string TimeSpan { get; set; }

    [JsonProperty("main")] public WeatherStatistic Statistic { get; set; }

    [JsonProperty("wind")] public WindStatus WindStatus { get; set; }

    [JsonProperty("weather")] public List<WeatherStatus> Status { get; set; }
}

public class WeatherStatus
{
    [JsonProperty("main")] public string CloudStatus { get; set; }

    public string Description { get; set; }
}

public class WindStatus
{
    public double Speed { get; set; }
}

public class WeatherStatistic
{
    [JsonProperty("temp")] public double Temperature { get; set; }

    [JsonProperty("feels_like")] public double FeelsLike { get; set; }

    [JsonProperty("temp_min")] public double MinTemperature { get; set; }

    [JsonProperty("temp_max")] public double MaxTemperature { get; set; }

    public double Pressure { get; set; }

    public double Humidity { get; set; }
}

public class CityResponse
{
    public string Name { get; set; }
    public string Country { get; set; }
}