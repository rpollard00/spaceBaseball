using Adapter.Sqlite.Interfaces;
using Microsoft.EntityFrameworkCore;
using SpaceBaseball.WebAPI;
using SpaceBaseball.Core;
using SpaceBaseball.Adapter.Sqlite;
using Microsoft.Extensions.DependencyInjection;
using SpaceBaseball.Adapter.Sqlite.Adapters;
using SpaceBaseball.Core.NameGenerator;
using SpaceBaseball.Core.Ports;

var api = new WebApi(args, options =>
{
    options.AddScoped<IBaseballDbContext, BaseballDbContext>();
    options.AddScoped<IPlayerRetriever, PlayerRetriever>();
    options.AddScoped<IPlayerService, PlayerService>(); 
    options.AddSingleton<INameGenerator, NameGenerator>();
});

await api.RunAsync();
