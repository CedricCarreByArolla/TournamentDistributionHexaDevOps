namespace TournamentDistributionHexa.Application.Models.Requests;

public record GetTournamentResponse
{
    public GetTournamentResponse()
    {

    }
    public GetTournamentResponse(long id, string name, DateTime? startDate, DateTime? endDate)
    {
        Id = id;
        Name = name;
        StartDate = startDate;
        EndDate = endDate;
    }
    public long Id { get; init; }
    public string Name { get; init; }
    public DateTime? StartDate { get; init; }
    public DateTime? EndDate { get; init; }
}
