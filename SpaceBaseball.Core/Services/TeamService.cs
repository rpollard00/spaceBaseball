using SpaceBaseball.Core.Dto;
using SpaceBaseball.Core.Mappers;
using SpaceBaseball.Core.Models;

namespace SpaceBaseball.Core.Services;

public class TeamService(PlayerService playerService)
{
    
    // given a lineup, order the hitters - generate the optimal lineup
    public Queue<PlayerDto> SetLineupOrder(TeamDto team)
    {
        throw new NotImplementedException();
    }

    public PlayerDto GetBestPlayerForPosition(List<PlayerDto> playerList, string position)
    {
        Console.WriteLine($"playerList count in GetBestPlayerForPosition -> {playerList.Count}");
        Console.WriteLine($"Selecting best player for position: {position}");
        // we look at each player in the playerList, 
        // we need to find the top player for the given position based on the position rating
        // i think this involves ordering playerList in descending order by rating for the input position
        var candidatePlayers = playerList.Select(p => new
            {
                Player = p,
                CurrentPosition = p.Positions.First(pr => pr.Position == position)
            }).ToList();

        foreach (var player in candidatePlayers)
        {
            Console.WriteLine($"Candidate {player.Player.FirstName} {player.Player.LastName}: Rating {player.CurrentPosition.Rating}");
        }

        var bestPlayer = candidatePlayers.OrderByDescending(p => p.CurrentPosition.Rating).First().Player;

        Console.WriteLine($"Selected best player {bestPlayer.FirstName} {bestPlayer.LastName}");
        return bestPlayer;

    }

    public void AssignPlayerPosition(Roster roster, List<PlayerDto> playerList, string position)
    {
            var player = GetBestPlayerForPosition(playerList, position);
            playerList.Remove(player); 
            switch (position)
            {
               case "SP": 
                   roster.StartingRotation.Add(new StartingRotationEntry()
                   {
                       Player = player.ToPlayer(),
                       Rank = roster.StartingRotation.Count + 1, 
                       Role = "SP",
                   });
                   break;
               case "RL":
                   roster.Bullpen.Add(new BullpenEntry()
                   {
                       Player = player.ToPlayer(),
                       Role = position,
                   });
                   break;
               default:
                   roster.PositionPlayers.Add(new PositionPlayerEntry()
                   {
                       Player = player.ToPlayer(),
                       Position = position,
                   });
                   break;
            }
    }
    
    public Roster SetRoster(List<PlayerDto> playerList)
    {
        if (playerList.Count < 26)
        {
            throw new InvalidOperationException("PlayerList must be at least 26 in length");
        }

        Dictionary<string, string> rosterPrecedence = new()
        {
            {"C", "SS"},
            {"SS", "CF"},
            {"CF", "3B"},
            {"3B", "2B"},
            {"2B", "RF"},
            {"RF", "1B"},
            {"1B", "LF"},
            {"LF", "DH"},
            {"DH", "C"},
        };
        var currentPosition = "C";

        Roster roster = new();
        
        while (playerList.Count > 0)
        {
            if (roster.StartingRotation.Count < 5)
            {
                AssignPlayerPosition(roster, playerList, "SP");  
            } else if (roster.Bullpen.Count < 8)
            {
                AssignPlayerPosition(roster, playerList, "RL");  
            }
            else
            {
                
                AssignPlayerPosition(roster, playerList, currentPosition);
                currentPosition = rosterPrecedence[currentPosition];
            }
            
            Console.WriteLine($"Input Player list count is now: {playerList.Count}");
        }

        return roster;
    }

    // sets the current lineup
    public KeyValuePair<string, PlayerDto> SetLineup(TeamDto team)
    {
        KeyValuePair<string, PlayerDto> lineup = new();
        throw new NotImplementedException();
    }
}