using System.ComponentModel.DataAnnotations;

namespace TournamentDistributionHexa.Application.Models.Requests
{
    public class EditTournamentRequest
    {
        public EditTournamentRequest()
        {

        }

        public long Id { get; set; }
        [Required]
        public string Nom { get; set; }
        public DateTime? DateDebut { get; set; }
        public DateTime? DateFin { get; set; }
    }
}
