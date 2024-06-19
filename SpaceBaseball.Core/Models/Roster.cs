using System.ComponentModel.DataAnnotations;

namespace SpaceBaseball.Core.Models;

public class Roster
{
    public int Id { get; set; }
    public List<BullpenEntry> Bullpen { get; set; } = new();
    public List<StartingRotationEntry> StartingRotation { get; set; } = new();
    public List<PositionPlayerEntry> PositionPlayers { get; set; } = new();
}

public class BullpenEntry
{
    public int Id { get; set; }
    public string Role { get; set; } = "";
    public Player Player { get; set; } = new();
}

public class StartingRotationEntry
{
    public int Id { get; set; }
    public string Role { get; set; } = "";
    [Range(1, 5)]
    public int Rank { get; set; }
    public Player Player { get; set; } = new();
}

public class PositionPlayerEntry
{
    public int Id { get; set; }
    public string Position { get; set; } = "";
    public Player Player { get; set; } = new();
}