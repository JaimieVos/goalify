using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Goalify.Core.Entities;

public class Player
{
    [Key]
    public Guid Id { get; init; }
    
    [Required]
    [MaxLength(30)]
    public required string Name { get; set; }
    
    [Required]
    public DateTime CreatedAt { get; init; }
    
    public DateTime? UpdatedAt { get; set; }

    public ICollection<Team> Teams { get; set; } = new List<Team>();
} 