using System.Text.Json;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using SpaceBaseball.Core.Ports;
using SpaceBaseball.Core.Ports.DataPersistence;
using SpaceBaseball.Core.Ports.Services;
using SpaceBaseball.Core.Services.Simulation;

namespace SpaceBaseball.WebAPI.Handlers;

public static class SimHandlers
{
    // internal static Task<PlayerDto?> GetPlayerByIdHandler(int id, [FromServices] IPlayerQueryService queryService)
    // TODO define AtBatResult 
    internal static async Task<IResult> SimAtBat(HttpContext context,
        [FromServices] IPlayerQueryService playerQueryService,
        [FromServices] IAtBatSimService atBatSimService)
    {
        var pitcherIdString = context.Request.Query["pitcherid"];
        var batterIdString = context.Request.Query["batterid"];

        if (string.IsNullOrEmpty(pitcherIdString) || string.IsNullOrEmpty(batterIdString))
        {
            return Results.BadRequest("PitcherId and BatterId are both required");
        }
        if (!long.TryParse(pitcherIdString, out var pitcherId))
        {
            return Results.BadRequest("Invalid pitcherId could not be parsed");
        }
        if (!long.TryParse(batterIdString, out var batterId))
        {
            return Results.BadRequest("Invalid batterId could not be parsed");
        }

        AtBatResult result = await atBatSimService.InvokeAtBat(pitcherId, batterId);
        Console.WriteLine($"Result of Invoked AB: {result}");

        return Results.Ok(result); 
    }
}