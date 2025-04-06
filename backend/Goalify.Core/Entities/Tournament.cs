using System.ComponentModel.DataAnnotations;
using Goalify.Core.Enums;

namespace Goalify.Core.Entities;

public class Tournament
{
    [Key]
    public Guid Id { get; init; }
    
    [Required]
    [MaxLength(100)]
    public required string Name { get; set; }
    
    public required TournamentFormat Format { get; init; }
    
    [Required]
    public DateTime StartDate { get; set; }
    
    public DateTime? EndDate { get; set; }
    
    [Required]
    public DateTime CreatedAt { get; init; }
    
    public DateTime? UpdatedAt { get; set; }

    public ICollection<Team> Teams { get; set; } = new List<Team>();
    
    public ICollection<TournamentStage> Stages { get; set; } = new List<TournamentStage>();
} 