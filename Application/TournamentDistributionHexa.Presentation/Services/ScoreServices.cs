using RestSharp;
using TournamentDistributionHexa.Application.Models.Requests;
using TournamentDistributionHexa.Application.Models.Responses;
using TournamentDistributionHexa.Presentation.Web.Services.Interfaces;

namespace TournamentDistributionHexa.Presentation.Web.Services
{
    public class ScoreServices : IScoreServices
    {
        private readonly RestClient _restClient;
        public ScoreServices(IConfiguration configuration)
        {
            _restClient = new RestClient(configuration["AppSettings:ServicesURL"]);
        }

        public async Task<List<GetScoreResponse>> GetTournamentScores(long tournamentId)
        {
            var request = new RestRequest($"Tournaments/{tournamentId}/Scores");
            var response = await _restClient.ExecuteGetAsync<List<GetScoreResponse>>(request);
            return response.Data;
        }
        public async Task<GetScoreResponse> GetById(long matchId, long playerId)
        {
            var request = new RestRequest($"Scores/{matchId}?joueurId={playerId}");
            var response = await _restClient.ExecuteGetAsync<GetScoreResponse>(request);
            return response.Data;
        }

        public async Task Update(EditScoreRequest scoreDTO)
        {
            var request = new RestRequest($"Scores", Method.Put);
            request.AddBody(scoreDTO);
            var response = await _restClient.ExecutePutAsync(request);
        }

        public async Task<IList<GetScoreResponse>> GetTournamentScoresByPlayer(long tournamentId, long playerId)
        {
            var request = new RestRequest($"Tournaments/{tournamentId}/Scores/Players/{playerId}");
            var response = await _restClient.ExecuteGetAsync<List<GetScoreResponse>>(request);
            return response.Data;
        }
    }
}
