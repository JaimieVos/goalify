using Goalify.Core.Entities;
using Goalify.Core.Repositories;
using Goalify.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace Goalify.Infrastructure.Repositories;

public class TournamentRepository(ApplicationDbContext context) : ITournamentRepository
{
    public async Task<Tournament?> GetByIdAsync(Guid id)
    {
        return await context.Tournaments
            .Include(t => t.Teams)
            .FirstOrDefaultAsync(t => t.Id == id);
    }

    public async Task<IEnumerable<Tournament>> GetAllAsync()
    {
        return await context.Tournaments
            .Include(t => t.Teams)
            .ToListAsync();
    }

    public async Task<Tournament> CreateAsync(Tournament tournament)
    {
        context.Tournaments.Add(tournament);
        await context.SaveChangesAsync();
        return tournament;
    }

    public async Task<Tournament?> UpdateAsync(Guid id, Tournament tournament)
    {
        var existingTournament = await context.Tournaments
            .Include(t => t.Teams)
            .FirstOrDefaultAsync(t => t.Id == id);
            
        if (existingTournament == null) return null;

        existingTournament.Name = tournament.Name;
        existingTournament.StartDate = tournament.StartDate;
        existingTournament.EndDate = tournament.EndDate;
        existingTournament.UpdatedAt = DateTime.UtcNow;

        await context.SaveChangesAsync();
        return existingTournament;
    }

    public async Task<bool> DeleteAsync(Guid id)
    {
        var tournament = await context.Tournaments.FindAsync(id);
        if (tournament == null) return false;

        context.Tournaments.Remove(tournament);
        await context.SaveChangesAsync();
        return true;
    }

    public async Task<bool> AddTeamToTournamentAsync(Guid tournamentId, Guid teamId)
    {
        var tournament = await context.Tournaments
            .Include(t => t.Teams)
            .FirstOrDefaultAsync(t => t.Id == tournamentId);
            
        var team = await context.Teams.FindAsync(teamId);
        
        if (tournament == null || team == null) return false;
        
        if (tournament.Teams.Any(t => t.Id == teamId)) return false;
        
        tournament.Teams.Add(team);
        await context.SaveChangesAsync();
        return true;
    }

    public async Task<bool> RemoveTeamFromTournamentAsync(Guid tournamentId, Guid teamId)
    {
        var tournament = await context.Tournaments
            .Include(t => t.Teams)
            .FirstOrDefaultAsync(t => t.Id == tournamentId);
            
        var team = await context.Teams.FindAsync(teamId);
        
        if (tournament == null || team == null) return false;
        
        if (!tournament.Teams.Any(t => t.Id == teamId)) return false;
        
        tournament.Teams.Remove(team);
        await context.SaveChangesAsync();
        return true;
    }
} 