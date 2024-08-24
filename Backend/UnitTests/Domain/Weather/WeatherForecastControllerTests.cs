using Application.Weather.Commands;
using Domain.Weather.Models;
using ErrorOr;
using FluentAssertions;
using MapsterMapper;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Moq;
using Presentation.Weather.Contracts;
using Presentation.Weather.Controllers;

namespace UnitTests.Domain.Weather;

public class WeatherForecastControllerTests
{
    private Mock<ISender> _mediatorMock { get; set; }
    private Mock<IMapper> _mapperMock { get; set; }

    public WeatherForecastControllerTests()
    {
        _mediatorMock = new Mock<ISender>();
        _mapperMock = new Mock<IMapper>();
    }

    [Fact]
    public async Task GetWeatherForecastByCity_IfCityIsCorrect_ShouldReturnWeatherForecast()
    {
        // Arrange
        const string city = "Kyiv";
        var command = new GetWeatherByCityCommand
        {
            City = city
        };
        var result = new List<WeatherForecast>()
        {
            new WeatherForecast
            {
                City = city,
                Date = default,
                Humidity = 123,
                Temperature = 123,
                CloudStatus = "Test",
                Pressure = 123,
                WindSpeed = 123
            }
        };
        var mapped = new List<WeatherForecastResponse>()
        {
            new()
            {
                City = city,
                Date = default,
                Humidity = 123,
                Temperature = 123,
                CloudStatus = "Test",
                Pressure = 123,
                WindSpeed = 123
            }
        };

        _mediatorMock.Setup(m => m.Send(It.IsAny<GetWeatherByCityCommand>(), It.IsAny<CancellationToken>())).Returns(Task.FromResult<ErrorOr<IEnumerable<WeatherForecast>>>(result));
        _mapperMock.Setup(m => m.Map<ICollection<WeatherForecastResponse>>(result)).Returns(mapped);
        var controller = new WeatherForecastController(_mediatorMock.Object, _mapperMock.Object);

        // Act
        var response = await controller.GetWeatherForecastByCity(city);
        var res = response as OkObjectResult;
        var returnedForecast = res.Value as IEnumerable<WeatherForecastResponse>;

        // Assert
        response.Should().NotBeNull();
        res.Should().NotBeNull();
        res.StatusCode.Should().Be(StatusCodes.Status200OK);
        returnedForecast.Should().BeEquivalentTo(mapped);
    }

    [Fact]
    public async Task GetWeatherByCoordinates_IfCoordinatesIsValid_ShouldReturnValidWeatherForecast()
    {
        // Arrange
        _mediatorMock
            .Setup(m => m
                .Send(It.IsAny<GetWeatherByCityCommand>(), It.IsAny<CancellationToken>()))
            .Returns(Task.FromResult<ErrorOr<IEnumerable<WeatherForecast>>>(new List<WeatherForecast>()));
        
        _mapperMock.Setup(m => m
            .Map<ICollection<WeatherForecastResponse>>(It.IsAny<ICollection<WeatherForecast>>()));

        var controller = new WeatherForecastController(_mediatorMock.Object, _mapperMock.Object);

        // Act
        var response = await controller.GetWeatherByCoordinates(string.Empty, string.Empty);

        // Assert
        response.Should().NotBeNull();
        var okResult = response as OkObjectResult;

        okResult.StatusCode.Should().Be(StatusCodes.Status200OK);
    }
}