using RestSharp;
using TournamentDistributionHexa.Application.Models.Requests;
using TournamentDistributionHexa.Application.Models.Responses;
using TournamentDistributionHexa.Presentation.Web.Services.Interfaces;

namespace TournamentDistributionHexa.Presentation.Web.Services
{
    public class TournamentServices : ITournamentServices
    {
        private readonly RestClient _restClient;
        public TournamentServices(IConfiguration configuration)
        {
            _restClient = new RestClient(configuration["AppSettings:ServicesURL"]);
        }

        public async Task<List<GetTournamentResponse>> All()
        {
            var request = new RestRequest($"Tournaments");
            var response = await _restClient.ExecuteGetAsync<List<GetTournamentResponse>>(request);
            return response.Data;
        }
        public async Task Create(CreateTournamentRequest createTournamentRequest)
        {
            var request = new RestRequest($"Tournaments");
            request.AddBody(createTournamentRequest);
            await _restClient.ExecutePostAsync(request);
        }
        public async Task<List<GetBurndownChartLineResponse>> GetBurndownChartLines(long tournamentId)
        {
            var request = new RestRequest($"Matchs/BurndownChartLines/{tournamentId}");
            var response = await _restClient.ExecuteGetAsync<List<GetBurndownChartLineResponse>>(request);
            return response.Data;
        }
    }
}
