using SpaceBaseball.Core.Dto;
using SpaceBaseball.Core.Models;

namespace SpaceBaseball.Core.Mappers;

public static class DtoMapper
{
    public static PlayerDto ToDto(this Player player)
    {
        PlayerDto dto = new()
        {
            Id = player.Id,
            FirstName = player.FirstName,
            LastName = player.LastName,
            Fielding = player.Fielding,
            HitChance = player.HitChance,
            AbilityScores = player.AbilityScores,
            Positions = player.Positions,
        };

        return dto;
    }

    public static Player ToPlayer(this PlayerDto dto)
    {
        Player player = new()
        {
            Id = dto.Id,
            FirstName = dto.FirstName,
            LastName = dto.LastName,
            Fielding = dto.Fielding,
            HitChance = dto.HitChance,
            AbilityScores = dto.AbilityScores,
            Positions = dto.Positions,
        };

        return player;
    }

    public static TeamDto ToDto(this Team team)
    {
        List<PlayerDto> rosterDto = new();

        TeamDto teamDto = new()
        {
            Id = team.Id,
            Name = team.Name,
            Location = team.Location,
            Ballpark = team.Ballpark,
            Roster = team.Roster,
        };

        return teamDto;
    }

    public static Team ToTeam(this TeamDto teamDto)
    {
        List<Player> roster = new();

        Team team = new()
        {
            Id = teamDto.Id,
            Name = teamDto.Name,
            Location = teamDto.Location,
            Ballpark = teamDto.Ballpark,
            Roster = teamDto.Roster,
        };

        return team;
    }
}