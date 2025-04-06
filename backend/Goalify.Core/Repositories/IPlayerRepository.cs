using Goalify.Core.Entities;

namespace Goalify.Core.Repositories;

public interface IPlayerRepository
{
    Task<Player?> GetByIdAsync(Guid id);
    Task<IEnumerable<Player>> GetAllAsync();
    Task<Player> CreateAsync(Player player);
    Task<Player?> UpdateAsync(Guid id, Player player);
    Task<bool> DeleteAsync(Guid id);
    Task<bool> AddToTeamAsync(Guid playerId, Guid teamId);
    Task<bool> RemoveFromTeamAsync(Guid playerId, Guid teamId);
} 