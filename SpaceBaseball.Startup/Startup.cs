using Adapter.Sqlite.Interfaces;
using SpaceBaseball.WebAPI;
using SpaceBaseball.Adapter.Sqlite;
using Microsoft.Extensions.DependencyInjection;
using SpaceBaseball.Adapter.Sqlite.Adapters;
using SpaceBaseball.Core.PlayerGenerator;
using SpaceBaseball.Core.Ports;

var api = new WebApi(args, options =>
{
    options.AddScoped<IBaseballDbContext, BaseballDbContext>();
    options.AddScoped<IPlayerRetriever, PlayerRetriever>();
    options.AddScoped<IPlayerCreator, PlayerCreator>();
    options.AddScoped<IPlayerGenerator, PlayerGenerator>();
    options.AddScoped<IPlayerService, PlayerService>(); 
    //options.AddSingleton<INameGenerator, NameGenerator>();
});

await api.RunAsync();
