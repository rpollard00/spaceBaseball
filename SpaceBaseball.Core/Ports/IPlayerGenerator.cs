using SpaceBaseball.Core.Dto;
using SpaceBaseball.Core.Services;
namespace SpaceBaseball.Core.Ports;

public interface IPlayerGenerator
{
    public PlayerDto GeneratePlayer(INameGenerator nameGenerator, PlayerService playerService);
}