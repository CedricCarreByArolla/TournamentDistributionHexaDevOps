using TournamentDistributionHexa.Application.Models.ValueObjects;

namespace TournamentDistributionHexa.Application.Models.Responses;

public record GetRankResponse
{
    public string PlayerName { get; init; }
    public Points Points { get; set; }
    public Percent Progression { get; set; }
}
