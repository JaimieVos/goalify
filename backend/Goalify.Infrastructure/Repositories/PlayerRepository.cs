using Goalify.Core.Entities;
using Goalify.Core.Repositories;
using Goalify.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace Goalify.Infrastructure.Repositories;

public class PlayerRepository(ApplicationDbContext context) : IPlayerRepository
{
    public async Task<Player?> GetByIdAsync(Guid id)
    {
        return await context.Players
            .Include(p => p.Teams)
            .FirstOrDefaultAsync(p => p.Id == id);
    }

    public async Task<IEnumerable<Player>> GetAllAsync()
    {
        return await context.Players
            .Include(p => p.Teams)
            .ToListAsync();
    }

    public async Task<Player> CreateAsync(Player player)
    {
        context.Players.Add(player);
        await context.SaveChangesAsync();
        return player;
    }

    public async Task<Player?> UpdateAsync(Guid id, Player player)
    {
        var existingPlayer = await context.Players
            .Include(p => p.Teams)
            .FirstOrDefaultAsync(p => p.Id == id);
            
        if (existingPlayer == null) return null;

        existingPlayer.Name = player.Name;
        existingPlayer.UpdatedAt = DateTime.UtcNow;

        await context.SaveChangesAsync();
        return existingPlayer;
    }

    public async Task<bool> DeleteAsync(Guid id)
    {
        var player = await context.Players.FindAsync(id);
        if (player == null) return false;

        context.Players.Remove(player);
        await context.SaveChangesAsync();
        return true;
    }

    public async Task<bool> AddToTeamAsync(Guid playerId, Guid teamId)
    {
        var player = await context.Players
            .Include(p => p.Teams)
            .FirstOrDefaultAsync(p => p.Id == playerId);
            
        var team = await context.Teams.FindAsync(teamId);
        
        if (player == null || team == null) return false;
        
        if (player.Teams.Any(t => t.Id == teamId)) return true;
        
        player.Teams.Add(team);
        await context.SaveChangesAsync();
        return true;
    }

    public async Task<bool> RemoveFromTeamAsync(Guid playerId, Guid teamId)
    {
        var player = await context.Players
            .Include(p => p.Teams)
            .FirstOrDefaultAsync(p => p.Id == playerId);
            
        var team = await context.Teams.FindAsync(teamId);
        
        if (player == null || team == null) return false;
        
        player.Teams.Remove(team);
        await context.SaveChangesAsync();
        return true;
    }
} 