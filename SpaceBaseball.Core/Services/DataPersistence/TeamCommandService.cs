using SpaceBaseball.Core.Dto;
using SpaceBaseball.Core.Mappers;
using SpaceBaseball.Core.Models;
using SpaceBaseball.Core.Ports.DataPersistence;

namespace SpaceBaseball.Core.Services.DataPersistence;

public class TeamCommandService(ITeamRepository teamRepository) : ITeamCommandService
{
    public async Task<Team?> AddTeam(TeamDto teamDto)
    {
        var team = teamDto.ToTeam();
        await teamRepository.Add(team);

        return team;
    }
}