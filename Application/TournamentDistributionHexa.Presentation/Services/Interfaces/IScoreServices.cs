using TournamentDistributionHexa.Application.Models.Requests;
using TournamentDistributionHexa.Application.Models.Responses;

namespace TournamentDistributionHexa.Presentation.Web.Services.Interfaces;

public interface IScoreServices
{
    Task<List<GetScoreResponse>> GetTournamentScores(long tournamentId);
    Task<GetScoreResponse> GetById(long matchId, long playerId);
    Task Update(EditScoreRequest score);
    Task<IList<GetScoreResponse>> GetTournamentScoresByPlayer(long tournamentId, long playerId);
}
