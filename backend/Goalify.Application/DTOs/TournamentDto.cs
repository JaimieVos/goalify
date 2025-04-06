using System.ComponentModel.DataAnnotations;

namespace Goalify.Application.DTOs;

public record CreateTournamentDto(
    [Required(ErrorMessage = "Tournament name is required")]
    [StringLength(100, ErrorMessage = "Tournament name cannot exceed 100 characters")]
    string Name,
    
    [Required(ErrorMessage = "Start date is required")]
    DateTime StartDate,
    
    DateTime? EndDate
);

public record UpdateTournamentDto(
    [Required(ErrorMessage = "Tournament name is required")]
    [StringLength(100, ErrorMessage = "Tournament name cannot exceed 100 characters")]
    string Name,
    
    [Required(ErrorMessage = "Start date is required")]
    DateTime StartDate,
    
    DateTime? EndDate
);

public record TournamentResponseDto(
    Guid Id,
    string Name,
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