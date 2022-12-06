namespace TournamentDistributionHexa.Domain.Scores;

public class ScoreDomain : IScoreDomain
{
    private readonly IScoreRepository _scoreRepository;
    public ScoreDomain(IScoreRepository scoreRepository)
    {
        _scoreRepository = scoreRepository;
    }

    public async Task<Score> Update(Score scoreDTO)
    {
        return await _scoreRepository.Update(scoreDTO);
    }

}
