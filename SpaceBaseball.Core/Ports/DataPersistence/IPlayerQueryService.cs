using SpaceBaseball.Core.Dto;

namespace SpaceBaseball.Core.Ports.DataPersistence;

public interface IPlayerQueryService
{
    Task<PlayerDto> GetPlayerById(long id);
}