namespace TournamentDistributionHexa.Application.Models.Requests
{
    public class GetPlayerResponse
    {
        public GetPlayerResponse(long id, string firstname, string lastname, string telephone)
        {
            Id = id;
            FirstName = firstname;
            LastName = lastname;
            Telephone = telephone;
        }
        public long Id { get; init; }
        public string FirstName { get; init; }
        public string LastName { get; init; }
        public string Telephone { get; init; }

    }
}