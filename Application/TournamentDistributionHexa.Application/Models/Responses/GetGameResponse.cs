namespace TournamentDistributionHexa.Application.Models.Requests
{
    public class GetGameResponse
    {
        public GetGameResponse(long id, string name)
        {
            Id = id;
            Name = name;
        }
        public long Id { get; init; }
        public string Name { get; init; }
    }
}