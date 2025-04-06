using Goalify.Core.Entities;
using Goalify.Core.Repositories;
using Goalify.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace Goalify.Infrastructure.Repositories;

public class TeamRepository(ApplicationDbContext context) : ITeamRepository
{
    public async Task<Team?> GetByIdAsync(Guid id)
    {
        return await context.Teams.FindAsync(id);
    }

    public async Task<IEnumerable<Team>> GetAllAsync()
    {
        return await context.Teams.ToListAsync();
    }

    public async Task<Team> CreateAsync(Team team)
    {
        context.Teams.Add(team);
        await context.SaveChangesAsync();
        return team;
    }

    public async Task<Team?> UpdateAsync(Guid id, Team team)
    {
        var existingTeam = await context.Teams.FindAsync(id);
        if (existingTeam == null) return null;

        existingTeam.Name = team.Name;
        existingTeam.Description = team.Description;
        existingTeam.UpdatedAt = DateTime.UtcNow;

        await context.SaveChangesAsync();
        return existingTeam;
    }

    public async Task<bool> DeleteAsync(Guid id)
    {
        var team = await context.Teams.FindAsync(id);
        if (team == null) return false;

        context.Teams.Remove(team);
        await context.SaveChangesAsync();
        return true;
    }
} 