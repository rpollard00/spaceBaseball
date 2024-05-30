using SpaceBaseball.Core.Dto;
using SpaceBaseball.Core.Mappers;
using SpaceBaseball.Core.Ports;

namespace SpaceBaseball.Core.Services.DataPersistence;

public class PlayerQueryService(IPlayerRepository playerRepository) : IPlayerQueryService
{
    private IPlayerRepository PlayerRepository { get; set; } = playerRepository;
    public async Task<PlayerDto?> GetPlayerById(long id)
    {
        Console.WriteLine($"Invoke PlayerService GetPlayerById {id}");
        var player = await PlayerRepository.GetById(id);
        return player?.ToDto();
    }
}