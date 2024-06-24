using Microsoft.AspNetCore.Mvc;
using SpaceBaseball.Core.Dto;
using SpaceBaseball.Core.Ports;
using SpaceBaseball.Core.Ports.DataPersistence;

namespace SpaceBaseball.WebAPI.Handlers;

public static class PlayerHandlers
{
    internal static async Task<IResult> GetPlayerByIdHandler(int id, [FromServices] IPlayerQueryService queryService)
    {
        Console.WriteLine($"Invoke endpoint player/id, id: {id}");
        var player = await queryService.GetPlayerById(id);
        return Results.Ok(player);
    }
}