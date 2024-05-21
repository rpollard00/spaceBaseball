using Adapter.Sqlite.Interfaces;
using Microsoft.EntityFrameworkCore;
using SpaceBaseball.Core.Mappers;
using SpaceBaseball.Core.Models;
using SpaceBaseball.Core.PlayerGenerator;
using SpaceBaseball.Core.Ports;
using SpaceBaseball.Core.Dto;

namespace SpaceBaseball.Adapter.Sqlite.Adapters;

public class PlayerRetriever(IBaseballDbContext dbContext) : IPlayerRetriever
{

    public async Task<Player?> GetPlayerById(long id)
    {
        Console.WriteLine($"Invoke Sqlite Adapter GetPlayerById {id}");
        Player? player = await dbContext.Players.Where(p => p.Id == id).FirstOrDefaultAsync();

        return player;
    }
}

public class PlayerCreator(IBaseballDbContext dbContext) : IPlayerCreator
{
    
    public async Task<Player> CreatePlayer(Player player)
    {
        await dbContext.Players.AddAsync(player);
        dbContext.SaveChanges();

        return player;
    }

    public async Task<PlayerDto> CreateRandomPlayer(INameGenerator nameGenerator, IPlayerGenerator playerGenerator)
    {
        var playerDto = playerGenerator.GeneratePlayer(nameGenerator);

        var player = playerDto.ToPlayer();
        
        await dbContext.Players.AddAsync(player);
        dbContext.SaveChanges();

        return player.ToDto();
    }
}