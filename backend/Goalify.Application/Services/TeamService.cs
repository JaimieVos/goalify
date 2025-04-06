using Goalify.Application.DTOs;
using Goalify.Core.Entities;
using Goalify.Core.Repositories;

namespace Goalify.Application.Services;

public class TeamService(ITeamRepository teamRepository) : ITeamService
{
    public async Task<TeamResponseDto> CreateTeamAsync(CreateTeamDto dto)
    {
        if (string.IsNullOrWhiteSpace(dto.Name))
        {
            throw new ArgumentException("Team name cannot be empty", nameof(dto.Name));
        }

        var team = new Team
        {
            Id = Guid.NewGuid(),
            Name = dto.Name,
            Description = dto.Description,
            CreatedAt = DateTime.UtcNow
        };

        var createdTeam = await teamRepository.CreateAsync(team);
        return MapToDto(createdTeam);
    }

    public async Task<TeamResponseDto?> GetTeamByIdAsync(Guid id)
    {
        var team = await teamRepository.GetByIdAsync(id);
        return team == null ? null : MapToDto(team);
    }

    public async Task<IEnumerable<TeamResponseDto>> GetAllTeamsAsync()
    {
        var teams = await teamRepository.GetAllAsync();
        return teams.Select(MapToDto);
    }

    public async Task<TeamResponseDto?> UpdateTeamAsync(Guid id, UpdateTeamDto dto)
    {
        if (string.IsNullOrWhiteSpace(dto.Name))
        {
            throw new ArgumentException("Team name cannot be empty", nameof(dto.Name));
        }

        var team = new Team
        {
            Id = id,
            Name = dto.Name,
            Description = dto.Description
        };

        var updatedTeam = await teamRepository.UpdateAsync(id, team);
        return updatedTeam == null ? null : MapToDto(updatedTeam);
    }

    public async Task<bool> DeleteTeamAsync(Guid id)
    {
        return await teamRepository.DeleteAsync(id);
    }

    private static TeamResponseDto MapToDto(Team team)
    {
        return new TeamResponseDto(
            team.Id,
            team.Name,
            team.Description,
            team.CreatedAt,
            team.UpdatedAt,
            team.Players.Select(p => new PlayerSummaryDto(p.Id, p.Name))
        );
    }
} 