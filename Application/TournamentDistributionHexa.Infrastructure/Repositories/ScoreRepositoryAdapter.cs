using Microsoft.EntityFrameworkCore;
using TournamentDistributionHexa.Domain.Scores;
using TournamentDistributionHexa.Infrastructure.Mappers;
using TournamentDistributionHexa.Infrastructure.Models;

namespace TournamentDistributionHexa.Infrastructure.Repositories;

public class ScoreRepositoryAdapter : IScoreRepository
{
    private readonly RepartitionTournoiContext _dbContext;
    public ScoreRepositoryAdapter(RepartitionTournoiContext dbContext)
    {
        _dbContext = dbContext;
    }

    public async Task<Domain.Scores.Score> Create(Domain.Scores.Score scoreDTO)
    {
        Models.Score score = ScoreMapper.Map(scoreDTO);
        _dbContext.Scores.Add(score);
        await _dbContext.SaveChangesAsync();
        return ScoreMapper.Map(score);
    }


    public async Task<Domain.Scores.Score> Update(Domain.Scores.Score scoreDTO)
    {
        Models.Score score = ScoreMapper.Map(scoreDTO);
        _dbContext.Attach(score).State = EntityState.Modified;
        await _dbContext.SaveChangesAsync();
        return ScoreMapper.Map(score);
    }
}