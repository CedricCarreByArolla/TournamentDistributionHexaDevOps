using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Newtonsoft.Json;
using TournamentDistributionHexa.Application.Models.Requests;
using TournamentDistributionHexa.Application.Models.Responses;
using TournamentDistributionHexa.Application.Models.ValueObjects;
using TournamentDistributionHexa.Presentation.Web.Services.Interfaces;

namespace TournamentDistributionHexa.Presentation.Web.Pages.Scores;

public class IndexModel : PageModel
{
    private readonly IScoreServices _scoreServices;
    private readonly ITournamentServices _tournamentServices;

    public IndexModel(IScoreServices scoreServices, ITournamentServices tournamentServices)
    {
        _scoreServices = scoreServices;
        _tournamentServices = tournamentServices;
        Classements = new List<GetRankResponse>();
    }

    public int TournoiProgress { get; set; }
    public IList<GetScoreResponse> Scores { get; set; } = default!;
    public IList<GetRankResponse> Classements { get; set; }
    public string BurndownChartLines { get; set; }

    public async Task<IActionResult> OnGet(long tournamentId, long? joueurId)
    {
        if (tournamentId == null)
        {
            return NotFound();
        }
        Scores = await _scoreServices.GetTournamentScores(tournamentId);
        if (Scores == null)
        {
            return NotFound();
        }
        if (joueurId != null)
        {
            Scores = await _scoreServices.GetTournamentScoresByPlayer(tournamentId, (long)joueurId);
        }
        CalculateRanks(Scores);

        var burndownChartLines = await _tournamentServices.GetBurndownChartLines(tournamentId);
        BurndownChartLines = JsonConvert.SerializeObject(burndownChartLines);
        return Page();
    }
    private void CalculateRanks(IList<GetScoreResponse> scores)
    {
        foreach (GetScoreResponse score in scores)
        {
            string key = $"{score.Player.LastName} {score.Player.FirstName}";
            var classement = Classements.FirstOrDefault(x => x.PlayerName == key);
            if (classement != null)
            {
                classement.Points.Value += score.Points;
                int nbMatchFinis = scores.Count(x => x.Player.Id == score.Player.Id && x.Match.EndDate != null);
                int nbMatchTotal = scores.Count(x => x.Player.Id == score.Player.Id);
                classement.Progression = new Percent(nbMatchFinis * 100 / nbMatchTotal);
            }
            else
                Classements.Add(new GetRankResponse() { PlayerName = key, Points = new Points(score.Points), Progression = new Percent(100 / scores.Count(x => x.Player.Id == score.Player.Id)) });
        }

        Classements = Classements.OrderByDescending(x => x.Points.Value).ToList();
    }
}
