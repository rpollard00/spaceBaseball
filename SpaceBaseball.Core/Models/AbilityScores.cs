using System.ComponentModel.DataAnnotations;

namespace SpaceBaseball.Core.Models;

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