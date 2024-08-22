namespace Presentation.Weather.Contracts;

public class WeatherForecastResponse
{
    public string City { get; set; }
    public string Date { get; set; }
    public double Humidity { get; set; }
    public double Temperature { get; set; }
    public string CloudStatus { get; set; }
    public double Pressure { get; set; }
    public double WindSpeed { get; set; }
}