using Microsoft.EntityFrameworkCore;
using Goalify.Core.Entities;

namespace Goalify.Infrastructure.Data;

public class ApplicationDbContext : DbContext
{
    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
        : base(options)
    {
    }

    public DbSet<Team> Teams { get; set; } = null!;
    public DbSet<Player> Players { get; set; } = null!;
    public DbSet<Tournament> Tournaments { get; set; } = null!;
    public DbSet<TournamentStage> TournamentStages { get; set; } = null!;
    public DbSet<Match> Matches { get; set; } = null!;

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        modelBuilder.Entity<Player>()
            .HasMany(p => p.Teams)
            .WithMany(t => t.Players);

        modelBuilder.Entity<Tournament>()
            .HasMany(t => t.Teams)
            .WithMany(t => t.Tournaments);

        modelBuilder.Entity<Tournament>()
            .HasMany(t => t.Stages)
            .WithOne(s => s.Tournament)
            .HasForeignKey(s => s.TournamentId)
            .OnDelete(DeleteBehavior.Cascade);

        modelBuilder.Entity<TournamentStage>()
            .HasMany(s => s.Matches)
            .WithOne(m => m.TournamentStage)
            .HasForeignKey(m => m.TournamentStageId)
            .OnDelete(DeleteBehavior.Cascade);

        modelBuilder.Entity<Match>()
            .HasOne(m => m.HomeTeam)
            .WithMany()
            .HasForeignKey(m => m.HomeTeamId)
            .OnDelete(DeleteBehavior.Restrict);

        modelBuilder.Entity<Match>()
            .HasOne(m => m.AwayTeam)
            .WithMany()
            .HasForeignKey(m => m.AwayTeamId)
            .OnDelete(DeleteBehavior.Restrict);
    }
} 