using Microsoft.AspNetCore.Mvc.RazorPages;
using TournamentDistributionHexa.Application.Models.Requests;
using TournamentDistributionHexa.Presentation.Web.Services.Interfaces;

namespace TournamentDistributionHexa.Application.Pages.Tournaments;

public class IndexModel : PageModel
{
    private readonly ITournamentServices _services;

    public IndexModel(ITournamentServices services)
    {
        _services = services;
    }

    public IList<GetTournamentResponse> Tournaments { get; set; } = default!;

    public async Task OnGet()
    {
        Tournaments = await _services.All();
    }
}
