using TournamentDistributionHexa.Domain.Players;

namespace TournamentDistributionHexa.Domain.Score;

public record MatchScore
{
    public MatchScore(Player player, int points)
    {
        Player = player;
        Points = points;
    }
    public int Points { get; init; }
    public Player Player { get; init; }
}