using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Config;

public static class DependencyInjection
{
    public static IServiceCollection AddConfiguration(this IServiceCollection services, IConfiguration configuration)
    {
        services.Configure<ApplicationConfiguration>(configuration.GetSection(ApplicationConfiguration.Section));
        return services;
    }
}