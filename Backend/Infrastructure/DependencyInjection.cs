using Config;
using Domain.Weather;
using Infrastructure.Weather;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Options;

namespace Infrastructure;

public static class DependencyInjection
{
    public static IServiceCollection AddInfrastructure(this IServiceCollection services, IConfiguration configuration)
    {
        using (var provider = services.BuildServiceProvider())
        {
            var config = provider.GetRequiredService<IOptions<ApplicationConfiguration>>().Value;
            Console.WriteLine(config.OpenWeatherMapKey);

            services.AddHttpClient<IWeatherForecastClient, WeatherForecastClient>((_, pr) =>
                pr.BaseAddress = new Uri(config.OpenWeatherMapRoute));
            return services;
        }
    }
}