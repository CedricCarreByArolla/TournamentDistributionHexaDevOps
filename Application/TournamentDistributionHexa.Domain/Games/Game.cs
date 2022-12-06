using TournamentDistributionHexa.Domain.Teams;

namespace TournamentDistributionHexa.Domain.Games;

public record Game
{
    public Game(GameId id, string name)
    {
        GameId = id;
        Name = name;
        Teams = new List<Team>();
    }
    public GameId GameId { get; }
    public string Name { get; }
    public List<Team> Teams { get; set; }
}