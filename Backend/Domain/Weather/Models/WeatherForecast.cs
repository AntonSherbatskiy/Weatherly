namespace Domain.Weather.Models;

public class WeatherForecast
{
    public string City { get; set; }
    public TimeSpan Date { get; set; }
    public double Humidity { get; set; }
    public double Temperature { get; set; }
    public string CloudStatus { get; set; }
    public double Pressure { get; set; }
    public double WindSpeed { get; set; }
}