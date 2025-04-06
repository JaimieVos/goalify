using Microsoft.AspNetCore.Mvc;
using Goalify.Application.DTOs;
using Goalify.Application.Services;

namespace Goalify.Api.Controllers;

[ApiController]
[Route("api/[controller]")]
public class PlayersController(IPlayerService playerService) : ControllerBase
{
    [HttpPost]
    public async Task<ActionResult<PlayerResponseDto>> CreatePlayer(CreatePlayerDto dto)
    {
        var player = await playerService.CreatePlayerAsync(dto);
        return CreatedAtAction(nameof(GetPlayer), new { id = player.Id }, player);
    }

    [HttpGet("{id:guid}")]
    public async Task<ActionResult<PlayerResponseDto>> GetPlayer(Guid id)
    {
        var player = await playerService.GetPlayerByIdAsync(id);
        if (player == null) return NotFound();
        return Ok(player);
    }

    [HttpGet]
    public async Task<ActionResult<IEnumerable<PlayerResponseDto>>> GetAllPlayers()
    {
        var players = await playerService.GetAllPlayersAsync();
        return Ok(players);
    }

    [HttpPut("{id:guid}")]
    public async Task<ActionResult<PlayerResponseDto>> UpdatePlayer(Guid id, UpdatePlayerDto dto)
    {
        var player = await playerService.UpdatePlayerAsync(id, dto);
        if (player == null) return NotFound();
        return Ok(player);
    }

    [HttpDelete("{id:guid}")]
    public async Task<ActionResult> DeletePlayer(Guid id)
    {
        var result = await playerService.DeletePlayerAsync(id);
        if (!result) return NotFound();
        return NoContent();
    }

    [HttpPost("{playerId:guid}/teams/{teamId:guid}")]
    public async Task<ActionResult> AddPlayerToTeam(Guid playerId, Guid teamId)
    {
        var result = await playerService.AddPlayerToTeamAsync(playerId, teamId);
        if (!result) return NotFound();
        return NoContent();
    }

    [HttpDelete("{playerId:guid}/teams/{teamId:guid}")]
    public async Task<ActionResult> RemovePlayerFromTeam(Guid playerId, Guid teamId)
    {
        var result = await playerService.RemovePlayerFromTeamAsync(playerId, teamId);
        if (!result) return NotFound();
        return NoContent();
    }
} 