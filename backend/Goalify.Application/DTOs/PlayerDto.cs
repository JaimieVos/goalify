using System.ComponentModel.DataAnnotations;

namespace Goalify.Application.DTOs;

public record CreatePlayerDto(
    [Required(ErrorMessage = "Player name is required")]
    [StringLength(30, ErrorMessage = "Player name cannot exceed 30 characters")]
    string Name
);

public record UpdatePlayerDto(
    [Required(ErrorMessage = "Player name is required")]
    [StringLength(30, ErrorMessage = "Player name cannot exceed 30 characters")]
    string Name
);

public record PlayerResponseDto(
    Guid Id,
    string Name,
    DateTime CreatedAt,
    DateTime? UpdatedAt,
    IEnumerable<TeamResponseDto> Teams
); 