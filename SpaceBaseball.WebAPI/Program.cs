using Microsoft.AspNetCore.Mvc;
using SpaceBaseball.Core.NameGeneration;
using SpaceBaseball.Core.Ports;
using SpaceBaseball.Core.Dto;

namespace SpaceBaseball.WebAPI;

public class WebApi
{
    private WebApplicationBuilder _builder;

    public WebApi(string[] args, Action<IServiceCollection> options)
    {
        
        _builder = WebApplication.CreateBuilder(args);
        
        _builder.Services.AddSingleton<INameGenerator, NameGenerator>();  
        
        options.Invoke(_builder.Services);
        // Add services to the container.
        // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
        _builder.Services.AddEndpointsApiExplorer();
        _builder.Services.AddSwaggerGen();
    }

    public Task RunAsync()
    {
        var app = _builder.Build();

        app.Services.GetRequiredService<INameGenerator>();
        // Configure the HTTP request pipeline.
        if (app.Environment.IsDevelopment())
        {
            app.UseSwagger();
            app.UseSwaggerUI();
        }

        app.UseHttpsRedirection();
        app.RegisterEndpoints();

        return app.RunAsync();
    }

}

public static class ApiEndpoints
{
    private static readonly string[] Summaries = new[]
            {
                "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
            };

    public static void RegisterEndpoints(this WebApplication app)
    {
        app.MapGet("/weatherforecast", () =>
        {
            var forecast = Enumerable.Range(1, 5).Select(index =>
                    new WeatherForecast
                    (
                        DateOnly.FromDateTime(DateTime.Now.AddDays(index)),
                        Random.Shared.Next(-20, 55),
                        Summaries[Random.Shared.Next(Summaries.Length)]
                    ))
                .ToArray();
            return forecast;
        })
        .WithName("GetWeatherForecast")
        .WithOpenApi();

        app.MapGet("/player/{id}", (int id, [FromServices]IPlayerService service) =>
        {
            Console.WriteLine($"Invoke endpoint player/id, id: {id}");
            var player = service.GetPlayerById(id);
            return player;
        })
        .WithName("GetPlayerById")
        .WithOpenApi();

        app.MapGet("/generator/name", ([FromServices]INameGenerator nameService) =>
        {

            var firstName = nameService.GetNameFromPool("firstName");
            var lastName = nameService.GetNameFromPool("lastName");
            Console.WriteLine($"Invoke endpoint generator/name");

            return $"{firstName} {lastName}";
        });
        app.MapGet("/generator/player",
            ([FromServices] IPlayerCreator playerCreator, [FromServices] INameGenerator nameGenerator) =>
            {
                var player = playerCreator.CreateRandomPlayer(nameGenerator);
                Console.WriteLine($"Invoke endpoint generator/player");

                return player;
            })
            .WithName("GenerateRandomPlayer")
            .WithOpenApi();
    }
    
    
}
record WeatherForecast(DateOnly Date, int TemperatureC, string? Summary)
{
    public int TemperatureF => 32 + (int)(TemperatureC / 0.5556);
}

public class PlayerService(IPlayerRetriever playerRetriever) : IPlayerService
{
    private IPlayerRetriever PlayerRetriever { get; set; } = playerRetriever;
    public async Task<PlayerDto?> GetPlayerById(long id)
    {
        Console.WriteLine($"Invoke PlayerService GetPlayerById {id}");
        var player = await PlayerRetriever.GetPlayerById(id);
        if (player == null)
        {
            return null;
        } 
        
        PlayerDto playerDto = new()
        {
            Id = player.Id,
            FirstName = player.FirstName,
            LastName = player.LastName,
            Fielding = player.Fielding,
            HitChance = player.HitChance
        };

        return playerDto;
    }
}