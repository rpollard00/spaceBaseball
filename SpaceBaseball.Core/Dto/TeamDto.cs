namespace SpaceBaseball.Core.Dto;

public class TeamDto
{
     
    public long Id { get; set; }
    public string Name { get; set; } = "";
    public string Location { get; set; } = "";
    public string Ballpark { get; set; } = "";
    public List<PlayerDto> Roster { get; set; } = new();
}