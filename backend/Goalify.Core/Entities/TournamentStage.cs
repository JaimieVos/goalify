using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Goalify.Core.Enums;

namespace Goalify.Core.Entities;

public class TournamentStage
{
    [Key]
    public Guid Id { get; init; }
    
    [Required]
    public StageType StageType { get; init; }
    
    public int Order { get; set; }
    
    [Required]
    public Guid TournamentId { get; init; }
    
    [ForeignKey(nameof(TournamentId))]
    public Tournament Tournament { get; init; } = null!;
    
    public ICollection<Match> Matches { get; set; } = new List<Match>();
}