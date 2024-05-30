using Adapter.Sqlite.Interfaces;
using SpaceBaseball.Core.Models;
using SpaceBaseball.Core.Ports.DataPersistence;

namespace SpaceBaseball.Adapter.Sqlite.Repositories;

public class TeamRepository(IBaseballDbContext dbContext) : ITeamRepository
{
    public async Task Add(Team team)
    {
        await dbContext.Teams.AddAsync(team);
        dbContext.SaveChanges();
    }

}