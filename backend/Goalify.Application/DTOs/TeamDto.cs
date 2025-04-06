using System.ComponentModel.DataAnnotations;

namespace Goalify.Application.DTOs;

public record CreateTeamDto(
    [Required(ErrorMessage = "Team name is required")]
    [StringLength(30, ErrorMessage = "Team name cannot exceed 30 characters")]
    string Name,
    
    [StringLength(200, ErrorMessage = "Description cannot exceed 200 characters")]
    string Description
);

public record UpdateTeamDto(
    [Required(ErrorMessage = "Team name is required")]
    [StringLength(30, ErrorMessage = "Team name cannot exceed 30 characters")]
    string Name,
    
    [StringLength(200, ErrorMessage = "Description cannot exceed 200 characters")]
    string Description
);

public record TeamResponseDto(
    Guid Id,
    string Name,
    string Description,
    DateTime CreatedAt,
    DateTime? UpdatedAt
); 