using MediatR;
using TournamentDistributionHexa.Application.Commands;
using TournamentDistributionHexa.Application.Validators;
using TournamentDistributionHexa.Domain.Repositories;
using TournamentDistributionHexa.Domain.Tournaments;

namespace TournamentDistributionHexa.Application.Handlers
{
    public class CreateTournamentCommandHandler : IRequestHandler<CreateTournamentCommand, IEnumerable<TournamentMatch>>
    {
        private readonly ITournamentDomain _tournamentDomain;

        public CreateTournamentCommandHandler(ITournamentDomain tournamentDomain)
        {
            _tournamentDomain = tournamentDomain;
        }

        public async Task<IEnumerable<TournamentMatch>> Handle(CreateTournamentCommand request, CancellationToken cancellationToken)
        {
            return _tournamentDomain.Create(request.Name, request.Players, request.Games);
        }
    }
}
