using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Presentation;

public static class DependencyInjection
{
    public static IServiceCollection AddPresentation(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddControllers().AddNewtonsoftJson();
        
        services.AddCors(options =>
        {
            options.AddPolicy("allow-all", policyBuilder =>
            {
                policyBuilder.AllowAnyOrigin();
            });
        });
        
        return services;
    }
}