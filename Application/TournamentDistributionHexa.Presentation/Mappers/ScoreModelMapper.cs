using TournamentDistributionHexa.Application.Models.Requests;

namespace TournamentDistributionHexa.Presentation.Web.Mappers
{
    public static class ScoreModelMapper
    {
        public static EditScoreRequest Map(GetScoreResponse getScoreResponse)
        {
            return new EditScoreRequest() { PlayerId = getScoreResponse.Player.Id, MatchId = getScoreResponse.Match.Id, Points = getScoreResponse.Points };
        }
    }
}
