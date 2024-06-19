namespace SpaceBaseball.Core.Models;

public class Team
{
    public long Id { get; set; }
    public string Name { get; set; } = "";
    public string Location { get; set; } = "";
    public string Ballpark { get; set; } = "";
    public Roster Roster { get; set; } = new();
}
    
