using SpaceBaseball.Core.Models;
using SpaceBaseball.Core.Dto;

namespace SpaceBaseball.Core.Ports;

public interface IPlayerCreator
{
   Task<Player> CreatePlayer(Player player);
   Task<PlayerDto> CreateRandomPlayer(INameGenerator nameGenerator, IPlayerGenerator playerGenerator);
}

public interface IPlayerRetriever
{
   Task<Player?> GetPlayerById(long id);
}