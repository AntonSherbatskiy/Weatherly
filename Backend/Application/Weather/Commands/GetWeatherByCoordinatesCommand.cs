using Domain.Weather.Models;
using MediatR;

namespace Application.Weather.Commands;

public class GetWeatherByCoordinatesCommand : IRequest<ErrorOr.ErrorOr<IEnumerable<WeatherForecast>>>
{
    public string Latitude { get; set; }
    public string Longitude { get; set; }
}