namespace TournamentDistributionHexa.Application.Models.Responses;

public record GetBurndownChartLineResponse
{
    public GetBurndownChartLineResponse(string period, int expected, int weekNumber)
    {
        this.period = period;
        this.expected = expected;
        this.weekNumber = weekNumber;
    }
    public string period { get; }
    public int expected { get;  }
    public int? actual { get; set; }
    public int weekNumber { get;  }
}