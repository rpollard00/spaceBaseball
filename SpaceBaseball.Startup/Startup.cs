using Adapter.Sqlite.Interfaces;
using SpaceBaseball.WebAPI;
using SpaceBaseball.Adapter.Sqlite;
using Microsoft.Extensions.DependencyInjection;
using SpaceBaseball.Adapter.Sqlite.Adapters;
using SpaceBaseball.Adapter.Sqlite.Repositories;
using SpaceBaseball.Core.Adapters.PlayerGenerator;
using SpaceBaseball.Core.Adapters.TeamGenerator;
using SpaceBaseball.Core.Ports;
using SpaceBaseball.Core.Ports.DataPersistence;
using SpaceBaseball.Core.Services;
using SpaceBaseball.Core.Services.DataPersistence;

var api = new WebApi(args, options =>
{
    options.AddScoped<IBaseballDbContext, BaseballDbContext>();
    options.AddScoped<IPlayerRepository, PlayerRepository>();
    options.AddScoped<IPlayerCommandService, PlayerCommandService>();
    options.AddScoped<IPlayerGenerator, PlayerGenerator>();
    options.AddScoped<ITeamRepository, TeamRepository>();
    options.AddScoped<ITeamCommandService, TeamCommandService>();
    options.AddScoped<ITeamGenerator, TeamGenerator>();
    options.AddScoped<IPlayerQueryService, PlayerQueryService>();
    options.AddSingleton<PlayerService>();
});

await api.RunAsync();
