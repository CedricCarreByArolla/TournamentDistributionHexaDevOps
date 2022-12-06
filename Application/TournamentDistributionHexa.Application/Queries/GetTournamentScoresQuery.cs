using MediatR;
using TournamentDistributionHexa.Application.Models.Requests;

namespace TournamentDistributionHexa.Application.Queries
{
    public class GetTournamentScoresQuery : IRequest<IEnumerable<GetScoreResponse>>
    {
        public long TournamentId { get; init; }
        public GetTournamentScoresQuery(long tournamentId)
        {
            TournamentId = tournamentId;
        }
    }
}
