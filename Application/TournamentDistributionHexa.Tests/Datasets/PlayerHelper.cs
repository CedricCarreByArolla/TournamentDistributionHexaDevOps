using TournamentDistributionHexa.Domain.Players;

namespace TournamentDistributionHexa.Tests.Datasets
{
    public static class PlayerHelper
    {
        public static List<Player> GetPlayers()
        {
            return new List<Player>()
            {
                new Player(1, "Nicolas","B",""),
                new Player(2, "Alexandra","F",""),
                new Player(3, "Jeremy","F",""),
                new Player(4, "Ludovic","R",""),
                new Player(5, "Julien","P",""),
                new Player(6, "Nicolas","F",""),
                new Player(7, "Corentin","C",""),
                new Player(8, "Corinne","O",""),
                new Player(9, "Laura","X",""),
                new Player(10, "Noémie","R",""),
                new Player(11, "Denis","R",""),
                new Player(12, "Gabriel","Y","")
            };
        }
        public static Player Get1Player()
        {
            return GetPlayers()[0];
        }
        public static List<Player> Get3Players()
        {
            return new List<Player>() { GetPlayers()[0], GetPlayers()[1], GetPlayers()[2] };
        }
    }
}
