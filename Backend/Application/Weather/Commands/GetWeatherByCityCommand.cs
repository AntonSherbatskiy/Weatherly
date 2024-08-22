using Domain.Weather.Models;
using ErrorOr;
using MediatR;

namespace Application.Weather.Commands;

public class GetWeatherByCityCommand : IRequest<ErrorOr<IEnumerable<WeatherForecast>>>
{
    public string City { get; set; }
}