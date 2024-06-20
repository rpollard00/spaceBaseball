using SpaceBaseball.Core.Dto;
using SpaceBaseball.Core.Mappers;
using SpaceBaseball.Core.Models;

namespace SpaceBaseball.Core.Services;

public class TeamService(PlayerService playerService)
{
    public List<string> BaseballPositions = new()
    {
        "SP",
        "RL",
        "C",
        "3B",
        "2B",
        "1B",
        "SS",
        "LF",
        "CF",
        "RF",
    };
    
    // given a lineup, order the hitters - generate the optimal lineup
    public Queue<PlayerDto> SetLineupOrder(TeamDto team)
    {
        throw new NotImplementedException();
    }

    public bool IsValidPosition(string position) => BaseballPositions.Contains(position);

    public PlayerDto GetBestPlayerForPosition(List<PlayerDto> playerList, string position)
    {
        if (!IsValidPosition(position))
        {
            throw new ArgumentException($"Given position string is invalid", position);
        }
        if (playerList.Count == 0)
        {
            throw new ArgumentOutOfRangeException("playerList is empty");
        }
        
        Console.WriteLine($"playerList count in GetBestPlayerForPosition -> {playerList.Count}");
        Console.WriteLine($"Selecting best player for position: {position}");
        
        var candidatePlayers = playerList.Select(p => new
            {
                Player = p,
                CurrentPosition = p.Positions.First(pr => pr.Position == position)
            }).ToList();

        // In the given list of players we are looking for the one with the top rating for the given position
        var bestPlayer = candidatePlayers.OrderByDescending(p => p.CurrentPosition.Rating).First().Player;

        Console.WriteLine($"Selected best player {bestPlayer.FirstName} {bestPlayer.LastName}");
        return bestPlayer;

    }

    private void AssignPlayerPosition(Roster roster, List<PlayerDto> playerList, string position)
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
               case var pos :
                   roster.PositionPlayers.Add(new PositionPlayerEntry()
                   {
                       Player = player.ToPlayer(),
                       Position = pos,
                   });
                   break;
            }
    }
    string NextPositionPriority(string prevPosition) =>
        prevPosition switch
        {
            "C" => "SS",
            "SS" => "CF",
            "CF" => "3B",
            "3B" => "2B",
            "2B" => "RF",
            "RF" => "1B",
            "1B" => "LF",
            "LF" => "DH",
            "DH" => "C",
            _ => throw new ArgumentException($"Invalid position {prevPosition} input."),
        };
    
    public Roster SetRoster(List<PlayerDto> playerList)
    {
        if (playerList.Count < 26)
        {
            throw new InvalidOperationException("PlayerList must be at least 26 in length");
        }

        var currentPosition = "C";
        Roster roster = new();
        PositionState positionState = PositionState.Pitchers;
        
        while (playerList.Count > 0)
        {
            switch (positionState)
            {
                case PositionState.Pitchers:
                    AssignPitcher(playerList, roster);
                    positionState = PositionState.PositionPlayers;
                break;
                
                case PositionState.PositionPlayers:
                    AssignPlayerPosition(roster, playerList, currentPosition);
                    currentPosition = NextPositionPriority(currentPosition);
                    positionState = PositionState.Pitchers;
                break;
            }
            
            Console.WriteLine($"Input Player list count is now: {playerList.Count}");
        }

        return roster;
    }

    private void AssignPitcher(List<PlayerDto> playerList, Roster roster)
    {
        if (roster.StartingRotation.Count < 5)
        {
            AssignPlayerPosition(roster, playerList, "SP");  
        }
        else if (roster.Bullpen.Count < 8)
        {
            AssignPlayerPosition(roster, playerList, "RL");  
        }
    }

    enum PositionState
    {
        Pitchers,
        PositionPlayers,
    } 

    // sets the current lineup
    public KeyValuePair<string, PlayerDto> SetLineup(TeamDto team)
    {
        KeyValuePair<string, PlayerDto> lineup = new();
        throw new NotImplementedException();
    }
}