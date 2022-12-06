namespace TournamentDistributionHexa.Domain.Scores;

public interface IScoreDomain
{
    Task<Score> Update(Score score);
}
