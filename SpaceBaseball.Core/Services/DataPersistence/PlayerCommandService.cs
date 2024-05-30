using SpaceBaseball.Core.Dto;
using SpaceBaseball.Core.Mappers;
using SpaceBaseball.Core.Models;
using SpaceBaseball.Core.Ports;
using SpaceBaseball.Core.Ports.DataPersistence;

namespace SpaceBaseball.Core.Services.DataPersistence;

public class PlayerCommandService(IPlayerRepository playerRepository) : IPlayerCommandService
{
    public async Task<Player?> AddPlayer(PlayerDto playerDto)
    {
        var player = await playerRepository.Add(playerDto.ToPlayer());

        return player;
    }

}