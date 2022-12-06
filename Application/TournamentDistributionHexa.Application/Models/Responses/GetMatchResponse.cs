namespace TournamentDistributionHexa.Application.Models.Requests;

public class GetMatchResponse
{
    public GetMatchResponse(long id, string name, DateTime? endDate)
    {
        Id = id;
        Name = name;
        EndDate = endDate;
    }
    public long Id { get; init; }
    public string Name { get; init; }
    public DateTime? EndDate { get; init; }
}