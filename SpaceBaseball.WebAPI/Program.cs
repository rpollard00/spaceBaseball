using SpaceBaseball.Core.Ports;
using SpaceBaseball.Core.Services.Generators.NameGeneration;
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
        nameGenerator.BuildNamePool("team", trainingDataReader.ReadNamesFromFile("../data/sampleTeams.txt"), lookbackSize: 3);
        nameGenerator.BuildNamePool("location", trainingDataReader.ReadNamesFromFile("../data/sampleCities.txt"), lookbackSize: 3);
        nameGenerator.BuildNamePool("ballpark", trainingDataReader.ReadNamesFromFile("../data/sampleBallparks.txt"), lookbackSize: 2);
        
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