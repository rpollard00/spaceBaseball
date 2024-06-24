using SpaceBaseball.Core.Dto;
using SpaceBaseball.Core.Mappers;
using SpaceBaseball.Core.Ports;
using SpaceBaseball.Core.Ports.DataPersistence;

namespace SpaceBaseball.Core.Services.DataPersistence;

public class PlayerQueryService(IPlayerRepository playerRepository) : IPlayerQueryService
{
    private IPlayerRepository PlayerRepository { get; set; } = playerRepository;
    public async Task<PlayerDto> GetPlayerById(long id)
    {
        Console.WriteLine($"Invoke PlayerService GetPlayerById {id}");
        try
        {
            var player = await PlayerRepository.GetById(id) ?? throw new ArgumentException($"Unable to find player by id {id}.");
            return player.ToDto();
        }
        catch (Exception ex)
        {
            throw new Exception("Invalid GetPlayerById request", ex);
        }
    }
}