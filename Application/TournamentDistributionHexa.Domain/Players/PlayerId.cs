namespace TournamentDistributionHexa.Domain.Players;

public record PlayerId
{
    public PlayerId(int id)
    {
        Id = id;
    }
    public int Id { get; }
}