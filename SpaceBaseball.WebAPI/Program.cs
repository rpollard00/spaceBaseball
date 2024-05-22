using SpaceBaseball.Core.NameGeneration;
using SpaceBaseball.Core.Ports;
using SpaceBaseball.Core.Dto;
using SpaceBaseball.WebAPI.Endpoints;

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

        var nameGenerator = app.Services.GetRequiredService<INameGenerator>();
        var trainingDataReader = new TrainingFileDataReader();
        nameGenerator.BuildNamePool("firstName", trainingDataReader.ReadNamesFromFile("../data/sampleFirstNames.txt")); 
        nameGenerator.BuildNamePool("lastName", trainingDataReader.ReadNamesFromFile("../data/sampleLastNames.txt")); 
        
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