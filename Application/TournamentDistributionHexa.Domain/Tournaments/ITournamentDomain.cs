using TournamentDistributionHexa.Domain.Games;
using TournamentDistributionHexa.Domain.Players;
using TournamentDistributionHexa.Domain.Tournaments;

namespace TournamentDistributionHexa.Domain.Repositories
{
    public interface ITournamentDomain
    {
        List<TournamentMatch> Create(string nom, IEnumerable<int> playerIds, IEnumerable<int> gameIds);
        List<TournamentMatch> GetAll();
        IList<Game> GetEvenlyDistributedGames(IList<Game> games, int playerCount);
        Task<Tournoi> Update(long id, string name, DateTime startDate, DateTime endDate);
    }
}