using TournamentDistributionHexa.Domain.Scores;

namespace TournamentDistributionHexa.Infrastructure.Mappers;

public static class ScoreMapper
{
    public static Models.Score Map(Domain.Scores.Score scoreDTO)
    {
        return new Models.Score() { JoueurId = scoreDTO.ScoreId.PlayerId, MatchId = scoreDTO.ScoreId.MatchId, Points = scoreDTO.Points };
    }

    public static Domain.Scores.Score Map(Models.Score score)
    {
        return new Domain.Scores.Score(new ScoreId(score.MatchId, score.JoueurId), score.Points ?? 0);
    }
}
