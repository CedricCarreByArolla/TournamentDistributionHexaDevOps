using MediatR;
using TournamentDistributionHexa.Application.Models.Requests;

namespace TournamentDistributionHexa.Application.Queries
{
    public class GetAllTournamentsQuery : IRequest<IEnumerable<GetTournamentResponse>>
    {
        public GetAllTournamentsQuery()
        {
        }
    }
}
