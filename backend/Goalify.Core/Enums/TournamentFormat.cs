using System.Text.Json.Serialization;

namespace Goalify.Core.Enums;

public enum TournamentFormat
{
    SingleElimination,
    DoubleElimination,
    RoundRobin,
    Swiss,
    GroupsKnockout,
    RoundRobinKnockout
}