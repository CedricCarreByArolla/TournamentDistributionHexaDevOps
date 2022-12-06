using System;

namespace TournamentDistributionHexa.Domain.Scores;

public record ScoreId
{
    public ScoreId(long matchId, long playerId)
    {
        MatchId = matchId;
        PlayerId = playerId;
    }

    public readonly long MatchId;
    public readonly long PlayerId;
}