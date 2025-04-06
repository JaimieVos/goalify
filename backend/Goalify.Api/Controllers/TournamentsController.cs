using Microsoft.AspNetCore.Mvc;
using Goalify.Application.DTOs;
using Goalify.Application.Services;

namespace Goalify.Api.Controllers;

[ApiController]
[Route("api/[controller]")]
public class TournamentsController(ITournamentService tournamentService) : ControllerBase
{
    [HttpPost]
    public async Task<ActionResult<TournamentResponseDto>> CreateTournament(CreateTournamentDto dto)
    {
        var tournament = await tournamentService.CreateTournamentAsync(dto);
        return CreatedAtAction(nameof(GetTournament), new { id = tournament.Id }, tournament);
    }

    [HttpGet("{id:guid}")]
    public async Task<ActionResult<TournamentResponseDto>> GetTournament(Guid id)
    {
        var tournament = await tournamentService.GetTournamentByIdAsync(id);
        if (tournament == null) return NotFound();
        return Ok(tournament);
    }

    [HttpGet]
    public async Task<ActionResult<IEnumerable<TournamentResponseDto>>> GetAllTournaments()
    {
        var tournaments = await tournamentService.GetAllTournamentsAsync();
        return Ok(tournaments);
    }

    [HttpPut("{id:guid}")]
    public async Task<ActionResult<TournamentResponseDto>> UpdateTournament(Guid id, UpdateTournamentDto dto)
    {
        var tournament = await tournamentService.UpdateTournamentAsync(id, dto);
        if (tournament == null) return NotFound();
        return Ok(tournament);
    }

    [HttpDelete("{id:guid}")]
    public async Task<ActionResult> DeleteTournament(Guid id)
    {
        var result = await tournamentService.DeleteTournamentAsync(id);
        if (!result) return NotFound();
        return NoContent();
    }

    [HttpPost("{tournamentId:guid}/teams/{teamId:guid}")]
    public async Task<ActionResult> AddTeamToTournament(Guid tournamentId, Guid teamId)
    {
        var result = await tournamentService.AddTeamToTournamentAsync(tournamentId, teamId);
        if (!result) return NotFound();
        return NoContent();
    }

    [HttpDelete("{tournamentId:guid}/teams/{teamId:guid}")]
    public async Task<ActionResult> RemoveTeamFromTournament(Guid tournamentId, Guid teamId)
    {
        var result = await tournamentService.RemoveTeamFromTournamentAsync(tournamentId, teamId);
        if (!result) return NotFound();
        return NoContent();
    }
} 