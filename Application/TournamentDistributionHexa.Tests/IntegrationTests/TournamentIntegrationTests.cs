using Microsoft.EntityFrameworkCore;
using TournamentDistributionHexa.Domain;
using TournamentDistributionHexa.Domain.Games;
using TournamentDistributionHexa.Domain.Players;
using TournamentDistributionHexa.Domain.Score;
using TournamentDistributionHexa.Domain.Tournament;
using TournamentDistributionHexa.Domain.Tournaments;
using TournamentDistributionHexa.Infrastructure.Models;
using TournamentDistributionHexa.Infrastructure.Repositories;
using TournamentDistributionHexa.Tests.Datasets;

namespace TournamentDistributionHexa.Tests.IntegrationTests;

public class TournamentIntegrationTests
{

        [Fact]
        public void CreateTournanement_With1Game_Should_Persist_1Tournoi()
        {
            //Arrange
            var options = new DbContextOptionsBuilder<RepartitionTournoiContext>()
            .UseInMemoryDatabase(databaseName: "RepartitionTournoi")
            .Options;
            InitializeInMemoryDatabaseData(options);
            using (var _context = new RepartitionTournoiContext(options))
            {
                ITournamentMatchRepository domain = new TournamentMatchRepositoryAdapter(_context);
                List<Player> players = PlayerHelper.GetPlayers();
                List<Game> games = new List<Game>() { GameHelper.Get1Game() };
                List<TournamentMatch> matchs = new List<TournamentMatch>()
            {
                new TournamentMatch(games[0]){ Scores = new List<MatchScore>(){
                    new MatchScore(players[0]),
                    new MatchScore(players[1]),
                    new MatchScore(players[2])
                } },
                new TournamentMatch(games[0]){  Scores = new List<MatchScore>(){
                    new MatchScore(players[3]),
                    new MatchScore(players[4]),
                    new MatchScore(players[5])
                } },
                new TournamentMatch(games[0]){  Scores = new List<MatchScore>(){
                    new MatchScore(players[6]),
                    new MatchScore(players[7]),
                    new MatchScore(players[8])
                } },
                new TournamentMatch(games[0]){  Scores = new List<MatchScore>(){
                    new MatchScore(players[9]),
                    new MatchScore(players[10]),
                    new MatchScore(players[11])
                } }

        };
            //Act
            var actualResult = domain.Create("2022-2023", matchs);

            //Assert
            Assert.True(actualResult.Count() == 4);
            Assert.True(actualResult.SelectMany(x => x.Scores).Count() == 12);
        }
    }

    private void InitializeInMemoryDatabaseData(DbContextOptions<RepartitionTournoiContext> options)
    {
        // Insert seed data into the database using one instance of the context
        using (var context = new RepartitionTournoiContext(options))
        {
            foreach (var player in PlayerHelper.GetPlayers())
            {
                context.Joueurs.Add(new Joueur() { Id = player.PlayerId, Nom = player.Lastname, Prenom = player.Firstname, Telephone = player.Telephone });
            }

            foreach (var game in GameHelper.GetGames())
            {
                context.Jeus.Add(new Jeu() { Id = game.GameId, Nom = game.Name });
            }
            context.SaveChanges();
        }
    }
}