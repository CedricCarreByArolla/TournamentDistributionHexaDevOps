using TournamentDistributionHexa.Domain.Tournaments;

namespace TournamentDistributionHexa.Infrastructure.Mappers;

public static class TournamentMapper
{
    public static Tournoi Map(Models.Tournoi tournoi)
    {
        return new Tournoi(new TournamentId((int)tournoi.Id), tournoi.Nom, tournoi.DateDebut, tournoi.DateFin);
    }
}
