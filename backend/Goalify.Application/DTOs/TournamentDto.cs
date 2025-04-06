using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;
using Goalify.Core.Enums;

namespace Goalify.Application.DTOs;

public record CreateTournamentDto(
    [Required(ErrorMessage = "Tournament name is required")]
    [StringLength(100, ErrorMessage = "Tournament name cannot exceed 100 characters")]
    string Name,
    
    [Required(ErrorMessage = "Tournament format is required")]
    [EnumDataType(typeof(TournamentFormat), ErrorMessage = "Invalid tournament format")]
    TournamentFormat Format,
    
    [Required(ErrorMessage = "Start date is required")]
    DateTime StartDate,
    
    DateTime? EndDate
);

public record UpdateTournamentDto(
    [Required(ErrorMessage = "Tournament name is required")]
    [StringLength(100, ErrorMessage = "Tournament name cannot exceed 100 characters")]
    string Name,
    
    [Required(ErrorMessage = "Tournament format is required")]
    [EnumDataType(typeof(TournamentFormat), ErrorMessage = "Invalid tournament format")]
    TournamentFormat Format,
    
    [Required(ErrorMessage = "Start date is required")]
    DateTime StartDate,
    
    DateTime? EndDate
);

public record TournamentResponseDto(
    Guid Id,
    string Name,
    TournamentFormat Format,
    DateTime StartDate,
    DateTime? EndDate,
    DateTime CreatedAt,
    DateTime? UpdatedAt,
    IEnumerable<TeamSummaryDto> Teams
);

public record TeamSummaryDto(
    Guid Id,
    string Name
); 