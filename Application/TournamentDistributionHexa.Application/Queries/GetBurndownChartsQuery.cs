using MediatR;
using TournamentDistributionHexa.Application.Models.Responses;

namespace TournamentDistributionHexa.Application.Queries
{
    public class GetBurndownChartsQuery : IRequest<IEnumerable<GetBurndownChartLineResponse>>
    {
        public long TournamentId { get; init; }
        public GetBurndownChartsQuery(long tournamentId)
        {
            TournamentId = tournamentId;
        }
    }
}
