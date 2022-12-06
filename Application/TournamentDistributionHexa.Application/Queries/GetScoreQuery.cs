using MediatR;
using TournamentDistributionHexa.Domain.Scores;

namespace TournamentDistributionHexa.Application.Queries
{
    public class GetScoreQuery : IRequest<Score>
    {
        public long MatchId { get; }
        public long JoueurId { get; }
        public GetScoreQuery(long matchId, long joueurId)
        {
            MatchId = matchId;
            JoueurId = joueurId;
        }
    }
}
