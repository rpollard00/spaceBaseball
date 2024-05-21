using SpaceBaseball.Core.Models;

namespace SpaceBaseball.Core.Ports;

public interface IPlayerCreator
{
   Task<Player> CreatePlayer(Player player);
}

public interface IPlayerRetriever
{
   Task<Player?> GetPlayerById(long id);
}