using Goalify.Core.Entities;

namespace Goalify.Core.Repositories;

public interface ITeamRepository
{
    Task<Team?> GetByIdAsync(Guid id);
    Task<IEnumerable<Team>> GetAllAsync();
    Task<Team> CreateAsync(Team team);
    Task<Team?> UpdateAsync(Guid id, Team team);
    Task<bool> DeleteAsync(Guid id);
} 