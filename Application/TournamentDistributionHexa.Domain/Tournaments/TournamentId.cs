namespace TournamentDistributionHexa.Domain.Tournaments;

public record TournamentId
{
    public TournamentId(long id)
    {
        Id = id;
    }

    public readonly long Id;
}