using MediatR;
using TournamentDistributionHexa.Application.Models.Requests;
using TournamentDistributionHexa.Domain.Tournaments;

namespace TournamentDistributionHexa.Application.Commands
{
    public class EditTournamentCommand : IRequest<Tournoi>
    {
        public long Id { get;}
        public string Name { get; }
        public DateTime? StartDate { get; }
        public DateTime? EndDate { get; }
        public EditTournamentCommand(EditTournamentRequest request)
        {
            Id = request.Id;
            Name = request.Nom;
            StartDate = request.DateDebut;
            EndDate = request.DateFin;
        }
    }
}
