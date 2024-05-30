namespace SpaceBaseball.Core.Models;

public class Player
{
    public long Id { get; set; }
    public string FirstName { get; set; } = "";
    public string LastName { get; set; } = "";
    public int HitChance { get; set; }
    public int Fielding { get; set; }
    public AbilityScores AbilityScores { get; set; } = new();
}