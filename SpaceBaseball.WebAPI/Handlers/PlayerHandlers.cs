using Microsoft.AspNetCore.Mvc;
using SpaceBaseball.Core.Dto;
using SpaceBaseball.Core.Ports;

namespace SpaceBaseball.WebAPI.Handlers;

public static class PlayerHandlers
{
    internal static Task<PlayerDto?> GetPlayerByIdHandler(int id, [FromServices] IPlayerQueryService queryService)
    {
        Console.WriteLine($"Invoke endpoint player/id, id: {id}");
        var player = queryService.GetPlayerById(id);
        return player;
    }
}