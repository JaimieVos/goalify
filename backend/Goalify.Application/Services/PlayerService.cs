using Goalify.Application.DTOs;
using Goalify.Core.Entities;
using Goalify.Core.Repositories;

namespace Goalify.Application.Services;

public class PlayerService(IPlayerRepository playerRepository) : IPlayerService
{
    public async Task<PlayerResponseDto> CreatePlayerAsync(CreatePlayerDto dto)
    {
        if (string.IsNullOrWhiteSpace(dto.Name))
        {
            throw new ArgumentException("Player name cannot be empty", nameof(dto.Name));
        }

        var player = new Player
        {
            Id = Guid.NewGuid(),
            Name = dto.Name,
            CreatedAt = DateTime.UtcNow
        };

        var createdPlayer = await playerRepository.CreateAsync(player);
        return MapToDto(createdPlayer);
    }

    public async Task<PlayerResponseDto?> GetPlayerByIdAsync(Guid id)
    {
        var player = await playerRepository.GetByIdAsync(id);
        return player == null ? null : MapToDto(player);
    }

    public async Task<IEnumerable<PlayerResponseDto>> GetAllPlayersAsync()
    {
        var players = await playerRepository.GetAllAsync();
        return players.Select(MapToDto);
    }

    public async Task<PlayerResponseDto?> UpdatePlayerAsync(Guid id, UpdatePlayerDto dto)
    {
        if (string.IsNullOrWhiteSpace(dto.Name))
        {
            throw new ArgumentException("Player name cannot be empty", nameof(dto.Name));
        }

        var player = new Player
        {
            Id = id,
            Name = dto.Name
        };

        var updatedPlayer = await playerRepository.UpdateAsync(id, player);
        return updatedPlayer == null ? null : MapToDto(updatedPlayer);
    }

    public async Task<bool> DeletePlayerAsync(Guid id)
    {
        return await playerRepository.DeleteAsync(id);
    }

    public async Task<bool> AddPlayerToTeamAsync(Guid playerId, Guid teamId)
    {
        return await playerRepository.AddToTeamAsync(playerId, teamId);
    }

    public async Task<bool> RemovePlayerFromTeamAsync(Guid playerId, Guid teamId)
    {
        return await playerRepository.RemoveFromTeamAsync(playerId, teamId);
    }

    private static PlayerResponseDto MapToDto(Player player)
    {
        return new PlayerResponseDto(
            player.Id,
            player.Name,
            player.CreatedAt,
            player.UpdatedAt,
            player.Teams.Select(t => new TeamResponseDto(
                t.Id,
                t.Name,
                t.Description,
                t.CreatedAt,
                t.UpdatedAt,
                t.Players.Select(p => new PlayerSummaryDto(p.Id, p.Name))
            ))
        );
    }
} 