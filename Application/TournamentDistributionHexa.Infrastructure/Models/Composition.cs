using System;
using System.Collections.Generic;

namespace TournamentDistributionHexa.Infrastructure.Models
{
    public partial class Composition
    {
        public long MatchId { get; set; }
        public long JeuId { get; set; }
        public long TournoiId { get; set; }

        public virtual Jeu Jeu { get; set; } = null!;
        public virtual Match Match { get; set; } = null!;
        public virtual Tournoi Tournoi { get; set; } = null!;
    }
}
