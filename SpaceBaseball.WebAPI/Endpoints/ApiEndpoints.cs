using SpaceBaseball.WebAPI.Handlers;

namespace SpaceBaseball.WebAPI.Endpoints;

public static class ApiEndpoints
{
    public static void RegisterEndpoints(this WebApplication app)
    {
        app.MapGet("/weatherforecast", WeatherHandlers.WeatherForecastHandler)
            .WithName("GetWeatherForecast")
            .WithOpenApi();

        app.MapGet("/player/{id}", PlayerHandlers.GetPlayerByIdHandler)
            .WithName("GetPlayerById")
            .WithOpenApi();

        app.MapGet("/generator/name", GeneratorHandlers.NameGeneratorHandler)
            .WithName("GenerateRandomName")
            .WithOpenApi();
        
        app.MapGet("/generator/player", GeneratorHandlers.PlayerGeneratorHandler)
            .WithName("GenerateRandomPlayer")
            .WithOpenApi();
    }
}