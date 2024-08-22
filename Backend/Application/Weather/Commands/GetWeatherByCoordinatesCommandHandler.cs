using Domain.Weather;
using Domain.Weather.Models;
using ErrorOr;
using MediatR;

namespace Application.Weather.Commands;

public class GetWeatherByCoordinatesCommandHandler : IRequestHandler<GetWeatherByCoordinatesCommand, ErrorOr<IEnumerable<WeatherForecast>>>
{
    public GetWeatherByCoordinatesCommandHandler(IWeatherForecastClient forecastClient)
    {
        _forecastClient = forecastClient;
    }

    private IWeatherForecastClient _forecastClient { get; set; }
    
    public async Task<ErrorOr<IEnumerable<WeatherForecast>>> Handle(
        GetWeatherByCoordinatesCommand request, 
        CancellationToken cancellationToken)
    {
        var result = await _forecastClient.GetForecastByCoordinates(request.Latitude, request.Longitude);

        if (result is null) return Error.Failure("Incorrect coordinates");

        return (dynamic)result;
    }
}