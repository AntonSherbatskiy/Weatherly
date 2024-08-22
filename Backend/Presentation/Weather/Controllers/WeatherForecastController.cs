using Application.Weather.Commands;
using MapsterMapper;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Presentation.Weather.Contracts;

namespace Presentation.Weather.Controllers;

[ApiController]
[Route("api/v1/weather")]
public class WeatherForecastController : ControllerBase
{
    public WeatherForecastController(ISender mediator, IMapper mapper)
    {
        _mediator = mediator;
        _mapper = mapper;
    }

    private ISender _mediator { get; }
    private IMapper _mapper { get; }

    [HttpGet("{city}")]
    public async Task<IActionResult> GetWeatherForecastByCity(string city)
    {
        var command = new GetWeatherByCityCommand
        {
            City = city
        };

        var result = await _mediator.Send(command);

        if (result.IsError) return BadRequest(result.FirstError.Description);

        return Ok(_mapper.Map<ICollection<WeatherForecastResponse>>(result.Value));
    }

    [HttpGet("{latitude}/{longitude}")]
    public async Task<IActionResult> GetWeatherByCoordinates(string latitude, string longitude)
    {
        var command = new GetWeatherByCoordinatesCommand
        {
            Latitude = latitude,
            Longitude = longitude
        };

        var result = await _mediator.Send(command);

        if (result.IsError) return BadRequest(result.FirstError.Description);

        return Ok(_mapper.Map<ICollection<WeatherForecastResponse>>(result.Value));
    }
}