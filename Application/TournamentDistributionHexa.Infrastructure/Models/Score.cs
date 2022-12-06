using System;
using System.Collections.Generic;

namespace TournamentDistributionHexa.Infrastructure.Models
{
    public partial class Score
    {
        public long MatchId { get; set; }
        public long JoueurId { get; set; }
        public int? Points { get; set; }

        public virtual Joueur Joueur { get; set; } = null!;
        public virtual Match Match { get; set; } = null!;
    }
}
