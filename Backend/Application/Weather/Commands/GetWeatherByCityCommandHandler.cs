using Domain.Weather;
using Domain.Weather.Models;
using ErrorOr;
using MediatR;

namespace Application.Weather.Commands;

public class GetWeatherByCityCommandHandler :
    IRequestHandler<GetWeatherByCityCommand, ErrorOr<IEnumerable<WeatherForecast>>>
{
    public GetWeatherByCityCommandHandler(IWeatherForecastClient forecastClient)
    {
        _forecastClient = forecastClient;
    }

    private IWeatherForecastClient _forecastClient { get; }

    public async Task<ErrorOr<IEnumerable<WeatherForecast>>> Handle(
        GetWeatherByCityCommand request,
        CancellationToken cancellationToken)
    { 
        var result = await _forecastClient.GetForecastByCity(request.City);

        if (result is null) return Error.Failure("Incorrect city");

        return (dynamic)result;
    }
}