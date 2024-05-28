using SpaceBaseball.Core.Dto;
using SpaceBaseball.Core.Models;

namespace SpaceBaseball.Core.Mappers;

public static class DtoMapper
{
    // I have not built the data model out at all yet
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
        };

        return player;
    }
}