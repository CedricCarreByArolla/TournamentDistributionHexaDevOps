using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using TournamentDistributionHexa.Application.Models.Requests;
using TournamentDistributionHexa.Presentation.Web.Mappers;
using TournamentDistributionHexa.Presentation.Web.Services.Interfaces;

namespace TournamentDistributionHexa.Presentation.Web.Pages.Scores
{
    public class EditModel : PageModel
    {
        private readonly IScoreServices _services;

        public EditModel(IScoreServices services)
        {
            _services = services;
        }

        [BindProperty]
        public EditScoreRequest ScoreRequest { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(long matchId, long joueurId)
        {
            ScoreRequest = ScoreModelMapper.Map(await _services.GetById(matchId, joueurId));
            if (ScoreRequest == null)
            {
                return NotFound();
            }
            return Page();
        }

        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync()
        {

            if (!ModelState.IsValid)
            {
                return Page();
            }
            await _services.Update(ScoreRequest);

            return RedirectToPage("/Tournois/Index");
        }
    }
}
