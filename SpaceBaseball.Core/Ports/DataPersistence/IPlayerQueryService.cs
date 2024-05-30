using SpaceBaseball.Core.Dto;

namespace SpaceBaseball.Core.Ports;

public interface IPlayerQueryService
{
    Task<PlayerDto?> GetPlayerById(long id);
}