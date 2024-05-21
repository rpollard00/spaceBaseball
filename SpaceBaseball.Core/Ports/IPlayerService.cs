using SpaceBaseball.Core.Dto;

namespace SpaceBaseball.Core.Ports;

public interface IPlayerService
{
    Task<PlayerDto?> GetPlayerById(long id);
}