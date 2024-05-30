using SpaceBaseball.Core.Models;
using SpaceBaseball.Core.Dto;

namespace SpaceBaseball.Core.Ports;

public interface IPlayerCommandService
{
   Task<Player> AddPlayer(Player player);
   Task<PlayerDto> CreateRandomPlayer(INameGenerator nameGenerator, IPlayerGenerator playerGenerator);
}