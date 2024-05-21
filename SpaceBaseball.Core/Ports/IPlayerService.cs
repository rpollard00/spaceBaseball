using SpaceBaseball.Core.Models;

namespace SpaceBaseball.Core.Ports;

public interface IPlayerService
{
    Task<PlayerDto?> GetPlayerById(long id);
}

public class PlayerDto
{
    public long Id { get; set; }
    public string FirstName { get; set; } = "";
    public string LastName { get; set; } = "";
    public int HitChance { get; set; }
    public int Fielding { get; set; }
}