using Microsoft.EntityFrameworkCore;
using TournamentDistributionHexa.Domain.Games;
using TournamentDistributionHexa.Domain.Score;
using TournamentDistributionHexa.Domain.Tournaments;
using TournamentDistributionHexa.Infrastructure.Mappers;
using TournamentDistributionHexa.Infrastructure.Models;

namespace TournamentDistributionHexa.Infrastructure.Repositories
{
    public class TournamentMatchRepositoryAdapter : ITournamentMatchRepository
    {
        private readonly RepartitionTournoiContext _context;
        public TournamentMatchRepositoryAdapter(RepartitionTournoiContext context)
        {
            _context = context;
        }
        public List<TournamentMatch> Create(string nom, IList<TournamentMatch> tournamentMatches)
        {
            Models.Tournoi tournoi = new Models.Tournoi()
            {
                Nom = nom
            };
            _context.Tournois.Add(tournoi);
            SaveMatchs(tournamentMatches, tournoi);
            _context.SaveChanges();
            return GetAll();
        }

        private void SaveMatchs(IList<TournamentMatch> tournamentMatchs, Models.Tournoi tournoi)
        {
            for (int matchIndex = 0; matchIndex < tournamentMatchs.Count; matchIndex++)
            {
                Match match = new Match() { Nom = $"Match {matchIndex}" };
                match.Scores = new List<Score>();
                List<int> joueurIds = GetJoueurIds(tournamentMatchs, matchIndex);
                foreach (int joueurId in joueurIds)
                {
                    match.Scores.Add(new Score() { JoueurId = joueurId });
                }
                _context.Matches.Add(match);
                SaveComposition(tournamentMatchs, tournoi, matchIndex, match);
            }
        }

        private List<int> GetJoueurIds(IList<TournamentMatch> tournamentMatchs, int i)
        {
            return _context.Joueurs.Where(x => tournamentMatchs[i].Scores.Select(y => y.Player.PlayerId.Id).Contains((int)x.Id)).Select(x => (int)x.Id).ToList();
        }

        private void SaveComposition(IList<TournamentMatch> tournamentMatchs, Models.Tournoi tournoi, int i, Match match)
        {
            Composition composition = new Composition() { JeuId = tournamentMatchs[i].Game.GameId.ID, MatchId = match.Id, TournoiId = tournoi.Id };
            _context.Compositions.Add(composition);
        }

        public List<TournamentMatch> GetAll()
        {
            List<TournamentMatch> result = new List<TournamentMatch>();
            var tournois = _context.Tournois.SelectMany(x => x.Compositions).Include(x => x.Jeu).Include(x => x.Match).ThenInclude(x => x.Scores).ThenInclude(x => x.Joueur);
            foreach (var tournoi in tournois)
            {
                result.Add(GetTournamentMatch(tournoi));
            }
            return result;
        }

        private TournamentMatch GetTournamentMatch(Composition composition)
        {
            TournamentMatch tournamentMatch = new TournamentMatch(new Game(new GameId((int)composition.JeuId), composition.Jeu.Nom));
            List<MatchScore> matchScores = new List<MatchScore>();
            foreach (var score in composition.Match.Scores)
            {
                matchScores.Add(MatchScoreMapper.GetMatchScore(score));
            }
            tournamentMatch.Scores = matchScores;
            return tournamentMatch;
        }
        public async Task<Domain.Tournaments.Tournoi> Update(long id, string name, DateTime startDate, DateTime endDate)
        {
            var tournoi = _context.Tournois.Find(id);
            if (tournoi == null)
            {
                throw new KeyNotFoundException($"{id} not found in database.");
            }
            tournoi.Nom = name;
            tournoi.DateDebut = startDate;
            tournoi.DateFin = endDate;
            _context.Attach(tournoi).State = EntityState.Modified;
            await _context.SaveChangesAsync();
            return TournamentMapper.Map(tournoi);
        }
    }
}
