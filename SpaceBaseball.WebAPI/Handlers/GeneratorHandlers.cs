using Microsoft.AspNetCore.Mvc;
using SpaceBaseball.Core.Dto;
using SpaceBaseball.Core.Mappers;
using SpaceBaseball.Core.Ports;
using SpaceBaseball.Core.Ports.DataPersistence;
using SpaceBaseball.Core.Services;

namespace SpaceBaseball.WebAPI.Handlers;

public static class GeneratorHandlers
{
    internal static async Task<PlayerDto> PlayerGeneratorHandler([FromServices] IPlayerCommandService playerCommandService, [FromServices] INameGenerator nameGenerator, [FromServices] IPlayerGenerator playerGenerator, [FromServices] PlayerService playerService)
    {

        Console.WriteLine($"Invoke endpoint generator/player");
        var player = playerGenerator.GeneratePlayer(nameGenerator, playerService);
        await playerCommandService.AddPlayer(player);

        return player;
    }

    internal static async Task<TeamDto> TeamGeneratorHandler([FromServices] ITeamCommandService teamCommandService,
        [FromServices] ITeamGenerator teamGenerator, [FromServices] IPlayerGenerator playerGenerator,
        [FromServices] INameGenerator nameGenerator,
        [FromServices] PlayerService playerService,
        [FromServices] TeamService teamService)
    {
        var teamDto = teamGenerator.GenerateTeam(nameGenerator, playerGenerator, playerService, teamService);
        var team = await teamCommandService.AddTeam(teamDto);
        Console.WriteLine($"Invoke endpoint generator/team");

        return team?.ToDto() ?? teamDto;

    }

    internal static string NameGeneratorHandler([FromServices] INameGenerator nameService)
    {
        var firstName = nameService.GetNameFromPool("firstName");
        var lastName = nameService.GetNameFromPool("lastName");
        Console.WriteLine($"Invoke endpoint generator/name");

        return $"{firstName} {lastName}";
    }

    internal static string TeamNameGeneratorHandler([FromServices] INameGenerator nameService)
    {
        var location = nameService.GetNameFromPool("location");
        var team = nameService.GetNameFromPool("team");
        Console.WriteLine($"Invoke endpoint generator/teamname");

        return $"{location} {team}";
    }

    internal static string BallparkNameGeneratorHandler([FromServices] INameGenerator nameService)
    {
        var ballpark = nameService.GetNameFromPool("ballpark");
        Console.WriteLine($"Invoke endpoint generator/ballparkname");

        return $"{ballpark}";
    }
}