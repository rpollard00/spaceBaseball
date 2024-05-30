using SpaceBaseball.Core.Adapters.StatGeneration;
using SpaceBaseball.Core.Dto;
using SpaceBaseball.Core.Ports;

namespace SpaceBaseball.Core.Adapters.PlayerGenerator;

// generates a random player and commits to persistent storage
public class PlayerGenerator : IPlayerGenerator
{
    public PlayerDto GeneratePlayer(INameGenerator nameGenerator)
    {
        PlayerDto player = new PlayerDto()
        {
            FirstName = nameGenerator.GetNameFromPool("firstName"),
            LastName = nameGenerator.GetNameFromPool("lastName"),
            AbilityScores = AbilityScoreGenerator.GenerateAbilityScoreBlock(), 
            Fielding = 50,
            HitChance = 50,
        };

        return player;
    }
}