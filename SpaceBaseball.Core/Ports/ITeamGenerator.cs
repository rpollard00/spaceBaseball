using SpaceBaseball.Core.Dto;

namespace SpaceBaseball.Core.Ports;

public interface ITeamGenerator
{
    
    public TeamDto GenerateTeam(INameGenerator nameGenerator, IPlayerGenerator playerGenerator);
}