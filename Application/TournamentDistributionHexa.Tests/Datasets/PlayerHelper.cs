using TournamentDistributionHexa.Domain.Players;

namespace TournamentDistributionHexa.Tests.Datasets
{
    public static class PlayerHelper
    {
        public static List<Player> GetPlayers()
        {
            return new List<Player>()
            {
                new Player(new PlayerId(1), "Nicolas","B",""),
                new Player(new PlayerId(2), "Alexandra","F",""),
                new Player(new PlayerId(3), "Jeremy","F",""),
                new Player(new PlayerId(4), "Ludovic","R",""),
                new Player(new PlayerId(5), "Julien","P",""),
                new Player(new PlayerId(6), "Nicolas","F",""),
                new Player(new PlayerId(7), "Corentin","C",""),
                new Player(new PlayerId(8), "Corinne","O",""),
                new Player(new PlayerId(9), "Laura","X",""),
                new Player(new PlayerId(10), "Noémie","R",""),
                new Player(new PlayerId(11), "Denis","R",""),
                new Player(new PlayerId(12), "Gabriel","Y","")
            };
        }
        public static Player Get1Player()
        {
            return GetPlayers()[0];
        }
        public static IEnumerable<Player> Get3Players()
        {
            return new List<Player>() { GetPlayers()[0], GetPlayers()[1], GetPlayers()[2] };
        }
    }
}
