using SpaceBaseball.Core.Dto;
namespace SpaceBaseball.Core.Ports;

public interface IPlayerGenerator
{
    public PlayerDto GeneratePlayer(INameGenerator nameGenerator);
}