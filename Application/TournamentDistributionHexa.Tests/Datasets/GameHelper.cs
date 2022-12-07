using TournamentDistributionHexa.Domain.Games;

namespace TournamentDistributionHexa.Tests.Datasets
{
    public static class GameHelper
    {
        public static List<Game> GetGames()
        {
            return new List<Game>()
            {
                new Game(new GameId(1), "Ark Nova"),
                new Game(new GameId(2), "Zombidice"),
                new Game(new GameId(3), "Perudo"),
                new Game(new GameId(4), "Living Forest"),
                new Game(new GameId(5), "Mille fiori"),
                new Game(new GameId(6), "Augustus"),
                new Game(new GameId(7), "Dune Imperium"),
                new Game(new GameId(8), "Cactus town"),
                new Game(new GameId(9), "Akropolis"),
                new Game(new GameId(10), "L'âge de pierre")
            };
        }
        public static Game Get1Game()
        {
            return GetGames()[0];
        }
        public static IEnumerable<Game> Get2Games()
        {
            return new List<Game>() { GetGames()[0], GetGames()[1] };
        }
    }
}
