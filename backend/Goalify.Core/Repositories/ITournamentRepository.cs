using Goalify.Core.Entities;

namespace Goalify.Core.Repositories;

public interface ITournamentRepository
{
    Task<Tournament?> GetByIdAsync(Guid id);
    Task<IEnumerable<Tournament>> GetAllAsync();
    Task<Tournament> CreateAsync(Tournament tournament);
    Task<Tournament?> UpdateAsync(Guid id, Tournament tournament);
    Task<bool> DeleteAsync(Guid id);
    Task<bool> AddTeamToTournamentAsync(Guid tournamentId, Guid teamId);
    Task<bool> RemoveTeamFromTournamentAsync(Guid tournamentId, Guid teamId);
} 