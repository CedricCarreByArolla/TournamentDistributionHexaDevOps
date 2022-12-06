using System.ComponentModel.DataAnnotations;

namespace TournamentDistributionHexa.Application.Models.Requests
{
    public class EditScoreRequest
    {
        public EditScoreRequest()
        {

        }

        [Required]
        public long MatchId { get; set; }
        [Required]
        public long PlayerId { get; set; }
        [Required]
        public int Points { get; set; }
    }
}
