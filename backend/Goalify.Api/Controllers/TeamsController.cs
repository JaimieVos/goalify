using Microsoft.AspNetCore.Mvc;
using Goalify.Application.DTOs;
using Goalify.Application.Services;

namespace Goalify.Api.Controllers;

[ApiController]
[Route("api/[controller]")]
public class TeamsController(ITeamService teamService) : ControllerBase
{
    [HttpPost]
    public async Task<ActionResult<TeamResponseDto>> CreateTeam(CreateTeamDto dto)
    {
        var team = await teamService.CreateTeamAsync(dto);
        return CreatedAtAction(nameof(GetTeam), new { id = team.Id }, team);
    }

    [HttpGet("{id:guid}")]
    public async Task<ActionResult<TeamResponseDto>> GetTeam(Guid id)
    {
        var team = await teamService.GetTeamByIdAsync(id);
        if (team == null) return NotFound();
        return Ok(team);
    }

    [HttpGet]
    public async Task<ActionResult<IEnumerable<TeamResponseDto>>> GetAllTeams()
    {
        var teams = await teamService.GetAllTeamsAsync();
        return Ok(teams);
    }

    [HttpPut("{id:guid}")]
    public async Task<ActionResult<TeamResponseDto>> UpdateTeam(Guid id, UpdateTeamDto dto)
    {
        var team = await teamService.UpdateTeamAsync(id, dto);
        if (team == null) return NotFound();
        return Ok(team);
    }

    [HttpDelete("{id:guid}")]
    public async Task<ActionResult> DeleteTeam(Guid id)
    {
        var result = await teamService.DeleteTeamAsync(id);
        if (!result) return NotFound();
        return NoContent();
    }
} 