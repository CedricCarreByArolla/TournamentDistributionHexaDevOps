using System;
using System.Collections.Generic;

namespace TournamentDistributionHexa.Infrastructure.Models
{
    public partial class Joueur
    {
        public Joueur()
        {
            Scores = new HashSet<Score>();
        }

        public long Id { get; set; }
        public string Nom { get; set; } = null!;
        public string Prenom { get; set; } = null!;
        public string Telephone { get; set; } = null!;

        public virtual ICollection<Score> Scores { get; set; }
    }
}
