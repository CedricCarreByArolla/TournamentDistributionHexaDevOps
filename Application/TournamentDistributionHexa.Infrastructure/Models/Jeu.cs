using System;
using System.Collections.Generic;

namespace TournamentDistributionHexa.Infrastructure.Models
{
    public partial class Jeu
    {
        public Jeu()
        {
            Compositions = new HashSet<Composition>();
        }

        public long Id { get; set; }
        public string Nom { get; set; } = null!;
        public int NbJoueursMin { get; set; }
        public int NbJoueursMax { get; set; }
        public long? MecaniqueId { get; set; }

        public virtual Mecanique? Mecanique { get; set; }
        public virtual ICollection<Composition> Compositions { get; set; }
    }
}
