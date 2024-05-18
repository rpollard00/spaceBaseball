using Adapter.Sqlite.Interfaces;
using Microsoft.EntityFrameworkCore;
using SpaceBaseball.WebAPI;
using SpaceBaseball.Core;
using SpaceBaseball.Adapter.Sqlite; 
using Microsoft.Extensions.DependencyInjection;

var api = new WebApi(args, options =>
{
    options.AddScoped<IBaseballDbContext, BaseballDbContext>();
});

await api.RunAsync();
