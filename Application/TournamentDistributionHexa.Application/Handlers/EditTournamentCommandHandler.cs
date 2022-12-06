using MediatR;
using TournamentDistributionHexa.Application.Commands;
using TournamentDistributionHexa.Domain.Repositories;
using TournamentDistributionHexa.Domain.Tournaments;

namespace TournamentDistributionHexa.Application.Handlers
{
    public class EditTournamentCommandHandler : IRequestHandler<EditTournamentCommand, Tournoi>
    {
        private readonly ITournamentDomain _tournamentDomain;

        public EditTournamentCommandHandler(ITournamentDomain tournamentDomain)
        {
            _tournamentDomain = tournamentDomain;
        }

        public async Task<Tournoi> Handle(EditTournamentCommand request, CancellationToken cancellationToken)
        {

            return await _tournamentDomain.Update(request.Id, request.Name, (DateTime)request.StartDate, (DateTime)request.EndDate);
        }
    }
}
