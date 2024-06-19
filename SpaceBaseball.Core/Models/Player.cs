namespace SpaceBaseball.Core.Models;

public class Player
{
    public long Id { get; set; }
    public string FirstName { get; set; } = "";
    public string LastName { get; set; } = "";
    public int HitChance { get; set; }
    public int Fielding { get; set; }
    public AbilityScores AbilityScores { get; set; } = new();
    public List<PositionsEntry> Positions { get; set; } = new();
}

public class PositionsEntry
{
    public int Id { get; set; }
    public string Position { get; set; } = "";
    public int Rating { get; set; }
}