using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Goalify.Core.Entities;

public class Team
{
    [Key]
    public Guid Id { get; init; }
    
    [Required]
    [MaxLength(30)]
    public required string Name { get; set; }
    
    [MaxLength(200)]
    public string Description { get; set; } = string.Empty;
    
    [Required]
    public DateTime CreatedAt { get; init; }
    
    public DateTime? UpdatedAt { get; set; }
} 