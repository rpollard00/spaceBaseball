using SpaceBaseball.Core.Dto;
using SpaceBaseball.Core.Models;
using SpaceBaseball.Core.Ports;

namespace SpaceBaseball.Core.Adapters.TeamGenerator;


public class TeamGenerator : ITeamGenerator
{
    private readonly int _rosterSize = 26;
    public TeamDto GenerateTeam(INameGenerator nameGenerator, IPlayerGenerator playerGenerator)
    {
        // generate roster  ??
        List<PlayerDto> roster = new();
        
        // 26 man easy for now
        for (int i = 0; i < _rosterSize; i++)
        {
            var currentPlayer = playerGenerator.GeneratePlayer(nameGenerator);
            roster.Add(currentPlayer);
        }
        
            
        TeamDto team = new()
        {
            Name = nameGenerator.GetNameFromPool("team"),
            Location = nameGenerator.GetNameFromPool("location"),
            Ballpark = nameGenerator.GetNameFromPool("ballpark"),
            Roster = roster,
        };
       // roster 26 man
       // 5 SP
       // 8 BP
       // 8 Starting Postions 1B, 2B, SS, 3B, C, LF, CF, RF
       // DH
       // 4 Backups - C, OF/INF, OF/INF, OF/INF
       return team;
    }
}