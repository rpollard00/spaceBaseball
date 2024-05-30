using SpaceBaseball.Core.Dto;
using SpaceBaseball.Core.Models;

namespace SpaceBaseball.Core.Ports.DataPersistence;

public interface ITeamCommandService
{
    public Task<Team?> AddTeam(TeamDto teamDto);
}

public interface ITeamRetriever
{
    
}