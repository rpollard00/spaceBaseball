using Adapter.Sqlite.Interfaces;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using SpaceBaseball.Core.Models;

namespace SpaceBaseball.Adapter.Sqlite;

public class BaseballDbContext : DbContext, IBaseballDbContext
{
   public DbSet<Player> Players { get; set; }
   public DbSet<Team> Teams { get; set; }
   private string? _connectionString;

   public BaseballDbContext()
   {
   }

   public BaseballDbContext(string connectionString)
   {
      _connectionString = connectionString;
   }

   protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
   {
      if (!optionsBuilder.IsConfigured)
      {
         if (_connectionString != null)
         {
            optionsBuilder.UseSqlite(_connectionString);
         }
         else
         {
   
            base.OnConfiguring(optionsBuilder);
   
            var builder = new ConfigurationBuilder().SetBasePath(Directory.GetCurrentDirectory()).AddJsonFile("appsettings.json");
            var config = builder.Build();
   
            var connectionStr = config.GetSection("ConnectionStrings")["Default"];
            optionsBuilder.UseSqlite(connectionStr);
         }
      }
      optionsBuilder.LogTo(Console.WriteLine);
   }
   public void EnsureDatabaseCreated() { Database.EnsureCreated(); }
}