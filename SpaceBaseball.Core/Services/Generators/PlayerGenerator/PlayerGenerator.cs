using SpaceBaseball.Core.Dto;
using SpaceBaseball.Core.Models;
using SpaceBaseball.Core.Ports;
using SpaceBaseball.Core.Services;
using SpaceBaseball.Core.Utils;

namespace SpaceBaseball.Core.Adapters.PlayerGenerator;

// generates a random player and commits to persistent storage
public class PlayerGenerator : IPlayerGenerator
{
    public PlayerDto GeneratePlayer(INameGenerator nameGenerator, PlayerService playerService)
    {
        PlayerDto player = new PlayerDto()
        {
            FirstName = nameGenerator.GetNameFromPool("firstName"),
            LastName = nameGenerator.GetNameFromPool("lastName"),
            AbilityScores = AbilityScoreGenerator.GenerateAbilityScoreBlock(),
            Fielding = 50,
            HitChance = 50,
        };

        List<PositionsEntry> positions = playerService.GetPreferredPositionList(player);

        player.Positions = positions;

        return player;
    }

}