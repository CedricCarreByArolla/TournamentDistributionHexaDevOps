namespace TournamentDistributionHexa.Domain.Tournaments;

public record Tournoi
{
    public Tournoi(TournamentId id, string name, DateTime? startDate, DateTime? endDate)
    {
        TournoiId = id;
        Nom = name;
        DateDebut = startDate;
        DateFin = endDate;
    }

    public TournamentId TournoiId { get; init; }
    public string Nom { get; init; }
    public DateTime? DateDebut { get; init; }
    public DateTime? DateFin { get; init; }
}