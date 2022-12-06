using TournamentDistributionHexa.Domain.Scores;

namespace TournamentDistributionHexa.Domain.Scores;

public interface IScoreRepository
{
    Task<Score> Create(Score score);
    Task<Score> Update(Score score);
}
