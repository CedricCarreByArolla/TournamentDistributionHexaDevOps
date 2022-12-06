using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using TournamentDistributionHexa.Application.Models.Requests;
using TournamentDistributionHexa.Presentation.Web.Services.Interfaces;

namespace TournamentDistributionHexa.Presentation.Web.Pages.Tournaments
{
    public class CreateModel : PageModel
    {
        private readonly ITournamentServices _services;

        public CreateModel(ITournamentServices services)
        {
            _services = services;
        }

        [BindProperty]
        public CreateTournamentRequest Tournament { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync()
        {
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
            await _services.Create(Tournament);

            return RedirectToPage("/Tournois/Index");
        }
    }
}
