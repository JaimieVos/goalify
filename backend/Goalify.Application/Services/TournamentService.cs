using Goalify.Application.DTOs;
using Goalify.Core.Entities;
using Goalify.Core.Repositories;

namespace Goalify.Application.Services;

public class TournamentService(ITournamentRepository tournamentRepository) : ITournamentService
{
    public async Task<TournamentResponseDto> CreateTournamentAsync(CreateTournamentDto dto)
    {
        // Validate that Name is not empty
        if (string.IsNullOrWhiteSpace(dto.Name))
        {
            throw new ArgumentException("Tournament name cannot be empty", nameof(dto.Name));
        }

        // Validate dates
        if (dto.EndDate.HasValue && dto.EndDate.Value < dto.StartDate)
        {
            throw new ArgumentException("End date cannot be before start date", nameof(dto.EndDate));
        }

        var tournament = new Tournament
        {
            Id = Guid.NewGuid(),
            Name = dto.Name,
            StartDate = dto.StartDate,
            EndDate = dto.EndDate,
            CreatedAt = DateTime.UtcNow
        };

        var createdTournament = await tournamentRepository.CreateAsync(tournament);
        return MapToDto(createdTournament);
    }

    public async Task<TournamentResponseDto?> GetTournamentByIdAsync(Guid id)
    {
        var tournament = await tournamentRepository.GetByIdAsync(id);
        return tournament == null ? null : MapToDto(tournament);
    }

    public async Task<IEnumerable<TournamentResponseDto>> GetAllTournamentsAsync()
    {
        var tournaments = await tournamentRepository.GetAllAsync();
        return tournaments.Select(MapToDto);
    }

    public async Task<TournamentResponseDto?> UpdateTournamentAsync(Guid id, UpdateTournamentDto dto)
    {
        if (string.IsNullOrWhiteSpace(dto.Name))
        {
            throw new ArgumentException("Tournament name cannot be empty", nameof(dto.Name));
        }

        if (dto.EndDate.HasValue && dto.EndDate.Value < dto.StartDate)
        {
            throw new ArgumentException("End date cannot be before start date", nameof(dto.EndDate));
        }

        var tournament = new Tournament
        {
            Id = id,
            Name = dto.Name,
            StartDate = dto.StartDate,
            EndDate = dto.EndDate
        };

        var updatedTournament = await tournamentRepository.UpdateAsync(id, tournament);
        return updatedTournament == null ? null : MapToDto(updatedTournament);
    }

    public async Task<bool> DeleteTournamentAsync(Guid id)
    {
        return await tournamentRepository.DeleteAsync(id);
    }

    public async Task<bool> AddTeamToTournamentAsync(Guid tournamentId, Guid teamId)
    {
        return await tournamentRepository.AddTeamToTournamentAsync(tournamentId, teamId);
    }

    public async Task<bool> RemoveTeamFromTournamentAsync(Guid tournamentId, Guid teamId)
    {
        return await tournamentRepository.RemoveTeamFromTournamentAsync(tournamentId, teamId);
    }

    private static TournamentResponseDto MapToDto(Tournament tournament)
    {
        return new TournamentResponseDto(
            tournament.Id,
            tournament.Name,
            tournament.StartDate,
            tournament.EndDate,
            tournament.CreatedAt,
            tournament.UpdatedAt,
            tournament.Teams.Select(t => new TeamSummaryDto(t.Id, t.Name))
        );
    }
} 