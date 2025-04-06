using Goalify.Application.DTOs;

namespace Goalify.Application.Services;

public interface IPlayerService
{
    Task<PlayerResponseDto> CreatePlayerAsync(CreatePlayerDto dto);
    Task<PlayerResponseDto?> GetPlayerByIdAsync(Guid id);
    Task<IEnumerable<PlayerResponseDto>> GetAllPlayersAsync();
    Task<PlayerResponseDto?> UpdatePlayerAsync(Guid id, UpdatePlayerDto dto);
    Task<bool> DeletePlayerAsync(Guid id);
    Task<bool> AddPlayerToTeamAsync(Guid playerId, Guid teamId);
    Task<bool> RemovePlayerFromTeamAsync(Guid playerId, Guid teamId);
} 