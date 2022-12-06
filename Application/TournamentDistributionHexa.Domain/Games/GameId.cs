using TournamentDistributionHexa.Domain.Teams;

namespace TournamentDistributionHexa.Domain.Games;

public record GameId
{
    public GameId(int id)
    {
        ID = id;
    }
    public int ID { get; }
}