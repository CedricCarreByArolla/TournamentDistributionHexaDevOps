using TournamentDistributionHexa.Domain.Players;
using TournamentDistributionHexa.Domain.Score;
using TournamentDistributionHexa.Infrastructure.Models;

namespace TournamentDistributionHexa.Infrastructure.Mappers
{
    public static class MatchScoreMapper
    {
        public static MatchScore GetMatchScore(Score score)
        {
            return new MatchScore(new Player(new PlayerId((int)score.JoueurId), score.Joueur.Prenom, score.Joueur.Nom, score.Joueur.Telephone), score.Points??0);
        }
    }
}
