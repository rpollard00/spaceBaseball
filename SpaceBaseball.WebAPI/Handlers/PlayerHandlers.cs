using Microsoft.AspNetCore.Mvc;
using SpaceBaseball.Core.Dto;
using SpaceBaseball.Core.Ports;

namespace SpaceBaseball.WebAPI.Handlers;

public static class PlayerHandlers
{
    internal static Task<PlayerDto?> GetPlayerByIdHandler(int id, [FromServices] IPlayerService service)
    {
        Console.WriteLine($"Invoke endpoint player/id, id: {id}");
        var player = service.GetPlayerById(id);
        return player;
    }
}