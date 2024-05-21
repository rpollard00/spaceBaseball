using SpaceBaseball.Core.Ports;
using SpaceBaseball.Core.Dto;

namespace SpaceBaseball.Core.PlayerGenerator;

// generates a random player and commits to persistent storage
public class PlayerGenerator : IPlayerGenerator
{
    public PlayerDto GeneratePlayer(INameGenerator nameGenerator)
    {
        PlayerDto player = new PlayerDto()
        {
            FirstName = nameGenerator.GetNameFromPool("firstName"),
            LastName = nameGenerator.GetNameFromPool("lastName"),
            Fielding = 50,
            HitChance = 50,
        };

        return player;
    }
}