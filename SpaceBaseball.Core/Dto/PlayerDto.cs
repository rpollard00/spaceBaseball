using SpaceBaseball.Core.Models;

namespace SpaceBaseball.Core.Dto;

public class PlayerDto
{
    public long Id { get; set; }
    public string FirstName { get; set; } = "";
    public string LastName { get; set; } = "";
    public int HitChance { get; set; }
    public int Fielding { get; set; }
    public AbilityScores AbilityScores { get; set; } = new();
    public List<PositionsEntry> Positions { get; set; } = new();
}