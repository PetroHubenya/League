using Microsoft.EntityFrameworkCore;
using League.Models;

namespace League.Data
{
  public class LeagueContext : DbContext
  {
    public LeagueContext(DbContextOptions<LeagueContext> options)
      : base(options)
    {
     
    }

    public DbSet<League.Models.League> Leagues { get; set; }
    public DbSet<Conference> Conferences { get; set; }
    public DbSet<Division> Divisions { get; set; }
    public DbSet<Team> Teams { get; set; }
    public DbSet<Player> Players { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
      modelBuilder.Entity<League.Models.League>().ToTable("League");
      modelBuilder.Entity<Conference>().ToTable("Conference");
      modelBuilder.Entity<Division>().ToTable("Division");
      modelBuilder.Entity<Team>().ToTable("Team");
      modelBuilder.Entity<Player>().ToTable("Player");
    }
  }
}
