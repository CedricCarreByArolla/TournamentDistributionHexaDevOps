using MediatR;
using TournamentDistributionHexa.Application.Models.Requests;

namespace TournamentDistributionHexa.Application.Queries
{
    public class GetTournamentScoresByPlayerQuery : IRequest<IEnumerable<GetScoreResponse>>
    {
        public long TournamentId { get; init; }
        public long PlayerId { get; init; }
        public GetTournamentScoresByPlayerQuery(long tournamentId, long playerId)
        {
            TournamentId = tournamentId;
            PlayerId = playerId;
        }
    }
}
