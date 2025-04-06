using Goalify.Application.DTOs;

namespace Goalify.Application.Services;

public interface ITeamService
{
    Task<TeamResponseDto> CreateTeamAsync(CreateTeamDto dto);
    Task<TeamResponseDto?> GetTeamByIdAsync(Guid id);
    Task<IEnumerable<TeamResponseDto>> GetAllTeamsAsync();
    Task<TeamResponseDto?> UpdateTeamAsync(Guid id, UpdateTeamDto dto);
    Task<bool> DeleteTeamAsync(Guid id);
} 