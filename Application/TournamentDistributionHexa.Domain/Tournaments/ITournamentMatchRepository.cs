namespace TournamentDistributionHexa.Domain.Tournaments;

public interface ITournamentMatchRepository
{
    List<TournamentMatch> Create(string nom, IList<TournamentMatch> tournamentMatches);
    List<TournamentMatch> GetAll();
    Task<Tournoi> Update(long id, string name, DateTime startDate, DateTime endDate);
}
