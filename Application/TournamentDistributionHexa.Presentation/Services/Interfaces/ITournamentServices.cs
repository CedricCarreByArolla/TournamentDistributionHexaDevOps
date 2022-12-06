using TournamentDistributionHexa.Application.Models.Requests;
using TournamentDistributionHexa.Application.Models.Responses;

namespace TournamentDistributionHexa.Presentation.Web.Services.Interfaces;

public interface ITournamentServices
{
    Task<List<GetTournamentResponse>> All();
    Task Create(CreateTournamentRequest request);
    Task<List<GetBurndownChartLineResponse>> GetBurndownChartLines(long tournamentId);
}
