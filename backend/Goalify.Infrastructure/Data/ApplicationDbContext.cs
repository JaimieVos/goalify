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

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        modelBuilder.Entity<Player>()
            .HasMany(p => p.Teams)
            .WithMany(t => t.Players);
    }
} 