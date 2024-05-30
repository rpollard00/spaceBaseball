using SpaceBaseball.Core.Dto;
using SpaceBaseball.Core.Models;

namespace SpaceBaseball.Core.Ports.DataPersistence;

public interface IPlayerCommandService
{
    public Task<Player?> AddPlayer(PlayerDto playerDto);
}