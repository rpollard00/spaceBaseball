using System.ComponentModel.DataAnnotations;

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

public class AbilityScores
{
    public int Id { get; set; }
    [Range(3, 18)]
    public int Strength { get; set; } 
    [Range(3, 18)]
    public int Dexterity { get; set; } 
    [Range(3, 18)]
    public int Constitution { get; set; } 
    [Range(3, 18)]
    public int Intelligence { get; set; } 
    [Range(3, 18)]
    public int Wisdom { get; set; } 
    [Range(3, 18)]
    public int Charisma { get; set; } 
}