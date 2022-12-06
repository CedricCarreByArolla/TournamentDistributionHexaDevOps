using System;
using System.Collections.Generic;

namespace TournamentDistributionHexa.Infrastructure.Models
{
    public partial class Tournoi
    {
        public Tournoi()
        {
            Compositions = new HashSet<Composition>();
        }

        public long Id { get; set; }
        public string Nom { get; set; } = null!;
        public DateTime? DateDebut { get; set; }
        public DateTime? DateFin { get; set; }

        public virtual ICollection<Composition> Compositions { get; set; }
    }
}
