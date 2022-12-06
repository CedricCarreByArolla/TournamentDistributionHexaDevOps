using MediatR;
using TournamentDistributionHexa.Application.Models.Requests;
using TournamentDistributionHexa.Domain.Games;
using TournamentDistributionHexa.Domain.Players;
using TournamentDistributionHexa.Domain.Tournaments;

namespace TournamentDistributionHexa.Application.Commands
{
    public class CreateTournamentCommand : IRequest<IEnumerable<TournamentMatch>>
    {
        public string Name { get; }
        public DateTime StartDate { get; }
        public DateTime EndDate { get; }
        public List<int> Players { get; }
        public List<int> Games { get; }
        public CreateTournamentCommand(CreateTournamentRequest request)
        {
            Name = request.Name;
            Players =  request.PlayerIds;
            Games =  request.GameIds;
            StartDate = request.StartDate;
            EndDate = request.EndDate;
        }

    }
}
