namespace TournamentDistributionHexa.Application.Models.Requests
{
    public class CreateTournamentRequest
    {
        public string Name { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public List<int> PlayerIds { get; set; }
        public List<int> GameIds { get; set; }
    }
}
