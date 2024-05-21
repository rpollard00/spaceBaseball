using Microsoft.AspNetCore.Mvc;
using SpaceBaseball.Core.Dto;
using SpaceBaseball.Core.Ports;

namespace SpaceBaseball.WebAPI.Handlers;

public static class GeneratorHandlers
{
    internal static Task<PlayerDto> PlayerGeneratorHandler([FromServices] IPlayerCreator playerCreator, [FromServices] INameGenerator nameGenerator, [FromServices] IPlayerGenerator playerGenerator)
    {
        var player = playerCreator.CreateRandomPlayer(nameGenerator, playerGenerator);
        Console.WriteLine($"Invoke endpoint generator/player");

        return player;
    }
    
    internal static string NameGeneratorHandler([FromServices] INameGenerator nameService)
    {
        var firstName = nameService.GetNameFromPool("firstName");
        var lastName = nameService.GetNameFromPool("lastName");
        Console.WriteLine($"Invoke endpoint generator/name");

        return $"{firstName} {lastName}";
    }
}