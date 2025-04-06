using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Goalify.Core.Entities;

public class Match 
{
    [Key]
    public Guid Id { get; init; }
    
    [Required]
    public Guid HomeTeamId { get; init; }
    
    [Required]
    public Guid AwayTeamId { get; init; }
    
    public int? HomeTeamScore { get; set; }
    public int? AwayTeamScore { get; set; }
    
    [Required]
    public Guid TournamentStageId { get; init; }

    [ForeignKey(nameof(HomeTeamId))]
    public Team HomeTeam { get; init; } = null!;
    
    [ForeignKey(nameof(AwayTeamId))]
    public Team AwayTeam { get; init; } = null!;
    
    [ForeignKey(nameof(TournamentStageId))]
    public TournamentStage TournamentStage { get; set; } = null!;
}