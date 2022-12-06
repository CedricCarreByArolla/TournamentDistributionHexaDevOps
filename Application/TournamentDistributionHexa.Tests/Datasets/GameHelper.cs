using TournamentDistributionHexa.Domain.Games;

namespace TournamentDistributionHexa.Tests.Datasets
{
    public static class GameHelper
    {
        public static List<Game> GetGames()
        {
            return new List<Game>()
            {
                new Game( 1, "Ark Nova"),
                new Game( 2, "Zombidice"),
                new Game( 3, "Perudo"),
                new Game( 4, "Living Forest"),
                new Game( 5, "Mille fiori"),
                new Game( 6, "Augustus"),
                new Game( 7, "Dune Imperium"),
                new Game( 8, "Cactus town"),
                new Game( 9, "Akropolis"),
                new Game( 10, "L'âge de pierre")
            };
        }
        public static Game Get1Game()
        {
            return GetGames()[0];
        }
        public static List<Game> Get2Games()
        {
            return new List<Game>() { GetGames()[0], GetGames()[1] };
        }
    }
}
