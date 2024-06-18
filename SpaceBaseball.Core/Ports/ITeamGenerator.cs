using SpaceBaseball.Core.Dto;
using SpaceBaseball.Core.Services;

namespace SpaceBaseball.Core.Ports;

public interface ITeamGenerator
{
    public TeamDto GenerateTeam(INameGenerator nameGenerator, IPlayerGenerator playerGenerator, PlayerService playerService);
}