using Goalify.Application.DTOs;

namespace Goalify.Application.Services;

public interface ITournamentService
{
    Task<TournamentResponseDto> CreateTournamentAsync(CreateTournamentDto dto);
    Task<TournamentResponseDto?> GetTournamentByIdAsync(Guid id);
    Task<IEnumerable<TournamentResponseDto>> GetAllTournamentsAsync();
    Task<TournamentResponseDto?> UpdateTournamentAsync(Guid id, UpdateTournamentDto dto);
    Task<bool> DeleteTournamentAsync(Guid id);
    Task<bool> AddTeamToTournamentAsync(Guid tournamentId, Guid teamId);
    Task<bool> RemoveTeamFromTournamentAsync(Guid tournamentId, Guid teamId);
} 