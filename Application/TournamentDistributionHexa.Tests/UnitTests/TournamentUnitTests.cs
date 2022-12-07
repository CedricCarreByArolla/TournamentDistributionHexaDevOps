using Microsoft.Extensions.Configuration;
using Moq;
using TournamentDistributionHexa.Domain.Games;
using TournamentDistributionHexa.Domain.Players;
using TournamentDistributionHexa.Domain.Repositories;
using TournamentDistributionHexa.Domain.Score;
using TournamentDistributionHexa.Domain.Tournaments;
using TournamentDistributionHexa.Tests.Datasets;

namespace TournamentDistributionHexa.Tests.UnitTests
{
    public class TournamentUnitTests
    {
        [Fact]
        public void CreateTournoi_Should_Return_10Matchs()
        {
            //Arrange
            ITournamentDomain domain = GetDomain();
            IEnumerable<Player> players = PlayerHelper.Get3Players();
            List<Game> games = GameHelper.GetGames();

            //Act
            List<TournamentMatch> matchs = domain.Create("2022-2023", players.Select(x=>x.PlayerId.Id), games.Select(x=>x.GameId.ID));

            //Assert
            Assert.True(matchs.Select(x => x.Game).Distinct().Count() == 10);
        }
        [Fact]
        public void CreateTournoi_Should_Return_1Matchs_Per_Game()
        {
            //Arrange
            ITournamentDomain domain = GetDomain();
            IEnumerable<Player> players = PlayerHelper.Get3Players();
            List<Game> games = GameHelper.GetGames();
            List<TournamentMatch> expectedMatchs = new List<TournamentMatch>()
            {
                new TournamentMatch(games[0]),
                new TournamentMatch(games[1]),
                new TournamentMatch(games[2]),
                new TournamentMatch(games[3]),
                new TournamentMatch(games[4]),
                new TournamentMatch(games[5]),
                new TournamentMatch(games[6]),
                new TournamentMatch(games[7]),
                new TournamentMatch(games[8]),
                new TournamentMatch(games[9]),
            };
            //Act
            List<TournamentMatch> matchs = domain.Create("2022-2023", players.Select(x => x.PlayerId.Id), games.Select(x => x.GameId.ID));
            //Assert
            Assert.True(expectedMatchs.Select(x => x.Game).Distinct().SequenceEqual(matchs.Select(x => x.Game).Distinct()));
        }
        [Fact]
        public void CreateTournoi_With1Game_Should_Return_3DifferentPlayers_Per_Match()
        {
            //Arrange
            ITournamentDomain domain = GetDomain();
            List<Player> players = PlayerHelper.GetPlayers();
            List<Game> games = new List<Game>() { GameHelper.Get1Game() };
            List<TournamentMatch> expectedMatchs = new List<TournamentMatch>()
            {
                new TournamentMatch(games[0]){ Scores = new List<MatchScore>(){
                    new MatchScore(players[0],0),
                    new MatchScore(players[1],0),
                    new MatchScore(players[2],0)
                } },
                new TournamentMatch(games[0]){  Scores = new List<MatchScore>(){
                    new MatchScore(players[3],0),
                    new MatchScore(players[4],0),
                    new MatchScore(players[5],0)
                } },
                new TournamentMatch(games[0]){  Scores = new List<MatchScore>(){
                    new MatchScore(players[6],0),
                    new MatchScore(players[7],0),
                    new MatchScore(players[8],0)
                } },
                new TournamentMatch(games[0]){  Scores = new List<MatchScore>(){
                    new MatchScore(players[9],0),
                    new MatchScore(players[10],0),
                    new MatchScore(players[11],0)
                } }

            };
            //Act
            List<TournamentMatch> matchs = domain.Create("2022-2023", players.Select(x => x.PlayerId.Id), games.Select(x => x.GameId.ID));
            //Assert
            Assert.Equivalent(expectedMatchs,matchs);
        }

        [Fact]
        public void GetAll_Should_Return_1_TournamentMatch()
        {
            //Arrange
            var adapter = new Mock<ITournamentMatchRepository>();
            adapter.Setup(x => x.GetAll()).Returns(new List<TournamentMatch>() {
                new TournamentMatch(GameHelper.Get1Game()) {
                    Scores = new List<MatchScore>(){
                        new MatchScore(PlayerHelper.Get1Player(),0)
                    }
                }
            });
            ITournamentDomain domain = GetDomain(adapter.Object);
            //Act
            List<TournamentMatch> matchs = domain.GetAll();
            //Assert
            Assert.True(matchs.Count == 1);
        }

        [Fact]
        public void CreateTournoi_With_10_Games_And_12_Players_Should_Have_1_Meeting_At_Least_Per_Player_Pairing()
        {
            //Arrange
            ITournamentDomain domain = GetDomain();
            List<Player> players = PlayerHelper.GetPlayers();
            List<Game> games = GameHelper.GetGames();

            int[][] MemberPairing = new int[players.Count][];
            for (int i = 0; i < players.Count; i++)
                MemberPairing[i] = new int[players.Count];

            //Act
            IList<Game> Games = domain.GetEvenlyDistributedGames(games, players.Count);

            foreach (Game Game in Games)
                foreach (var Team in Game.Teams)
                    foreach (int Member in Team.Players)
                        foreach (int OtherMember in Team.Players)
                            if (Member != OtherMember)
                                MemberPairing[Member][OtherMember]++;

            //Assert
            for (int i = 0; i < players.Count; i++)
                for (int j = 0; j < players.Count; j++)
                {
                    int PairingCount = MemberPairing[i][j];
                    Assert.True(i == j || PairingCount > 0);
                }
        }

        private ITournamentDomain GetDomain()
        {
            var adapter = new Mock<ITournamentMatchRepository>();
            return new TournamentDomain(adapter.Object, GetConfiguration());
        }
        private ITournamentDomain GetDomain(ITournamentMatchRepository adapter)
        {
            return new TournamentDomain(adapter, GetConfiguration());
        }
        private IConfiguration GetConfiguration()
        {
            var configuration = new Mock<IConfiguration>();
            configuration.Setup(x => x["AppSettings:NumberOfPlayersByTeam"]).Returns("3");
            return configuration.Object;
        }

    }

}