using Adapter.Sqlite.Interfaces;
using Microsoft.EntityFrameworkCore;
using SpaceBaseball.Core.Mappers;
using SpaceBaseball.Core.Models;
using SpaceBaseball.Core.Ports;
using SpaceBaseball.Core.Dto;
using SpaceBaseball.Core.Ports.DataPersistence;

namespace SpaceBaseball.Adapter.Sqlite.Adapters;

public class PlayerRepository(IBaseballDbContext dbContext) : IPlayerRepository
{

    public async Task<Player?> GetById(long id)
    {
        Console.WriteLine($"Invoke Sqlite Adapter GetPlayerById {id}");
        Player? player = await dbContext.Players.Include(p => p.AbilityScores).Include(p => p.Positions).Where(p => p.Id == id).FirstOrDefaultAsync();
        return player;
    }

    public async Task<Player?> Add(Player player)
    {
        await dbContext.Players.AddAsync(player);
        dbContext.SaveChanges();

        return player;
    }
}

// public class TeamCommandService(IBaseballDbContext dbContext) : ITeamCommandService
// {
//     public async Task<TeamDto> CreateRandomTeam(ITeamGenerator teamGenerator, INameGenerator nameGenerator, IPlayerGenerator playerGenerator)
//     {
//         var teamDto = teamGenerator.GenerateTeam(nameGenerator, playerGenerator);
//
//         var team = teamDto.ToTeam();
//
//         await dbContext.Teams.AddAsync(team);
//         dbContext.SaveChanges();
//
//         return team.ToDto();
//     }
// }