using Application;
using Config;
using Infrastructure;
using Presentation;
using Shared;

namespace Host;

public class Program
{
    public static void Main(string[] args)
    {
        var builder = WebApplication.CreateBuilder(args);
        builder.Services.AddSwaggerGen();
        builder.Services
            .AddShared(builder.Configuration)
            .AddConfiguration(builder.Configuration)
            .AddApplication(builder.Configuration)
            .AddPresentation(builder.Configuration)
            .AddInfrastructure(builder.Configuration);

        var app = builder.Build();
        app.UseCors("allow-all");
        if (app.Environment.IsDevelopment())
        {
            app.UseSwagger();
            app.UseSwaggerUI();
        }

        app.MapControllers();
        app.Run();
    }
}