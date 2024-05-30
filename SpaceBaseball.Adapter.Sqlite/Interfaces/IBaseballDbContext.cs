using SpaceBaseball.Core.Models;
using Microsoft.EntityFrameworkCore;
namespace Adapter.Sqlite.Interfaces;

public interface IBaseballDbContext
{   
    public DbSet<Player> Players { get; set; }
    public DbSet<Team> Teams { get; set; }

    int SaveChanges();
    void EnsureDatabaseCreated();
}