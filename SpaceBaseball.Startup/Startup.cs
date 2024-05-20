using Adapter.Sqlite.Interfaces;
using Microsoft.EntityFrameworkCore;
using SpaceBaseball.WebAPI;
using SpaceBaseball.Core;
using SpaceBaseball.Adapter.Sqlite;
using Microsoft.Extensions.DependencyInjection;
using SpaceBaseball.Core.NameGenerator;
using SpaceBaseball.Core.Ports;

var api = new WebApi(args, options =>
{
    options.AddScoped<IBaseballDbContext, BaseballDbContext>();
    options.AddSingleton<INameGenerator, NameGenerator>();
});

await api.RunAsync();
