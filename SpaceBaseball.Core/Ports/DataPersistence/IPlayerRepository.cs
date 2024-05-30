using SpaceBaseball.Core.Models;

namespace SpaceBaseball.Core.Ports;

public interface IPlayerRepository
{
    Task<Player?> GetById(long id);
    Task<Player?> Add(Player player);
}