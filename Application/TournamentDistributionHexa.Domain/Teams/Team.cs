namespace TournamentDistributionHexa.Domain.Teams;

public record Team
{
	public Team()
	{
		Players = new List<int>();
	}
    public List<int> Players { get; set; }
}