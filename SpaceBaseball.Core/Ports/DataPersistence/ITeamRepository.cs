using SpaceBaseball.Core.Models;

namespace SpaceBaseball.Core.Ports.DataPersistence;

public interface ITeamRepository
{
    public Task Add(Team team);
}