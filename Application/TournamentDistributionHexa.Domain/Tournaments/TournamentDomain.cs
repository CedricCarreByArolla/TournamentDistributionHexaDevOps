using Microsoft.Extensions.Configuration;
using TournamentDistributionHexa.Domain.Games;
using TournamentDistributionHexa.Domain.Players;
using TournamentDistributionHexa.Domain.Score;
using TournamentDistributionHexa.Domain.Teams;
using TournamentDistributionHexa.Domain.Tournaments;

namespace TournamentDistributionHexa.Domain.Repositories
{
    public class TournamentDomain : ITournamentDomain
    {
        public const int NUMBER_PLAYERS_PER_MATCH = 3;
        private readonly ITournamentMatchRepository _repositoryAdapter;
        private readonly IConfiguration _configuration;
        public TournamentDomain(ITournamentMatchRepository tournamentRepositoryAdapter, IConfiguration configuration)
        {
            _repositoryAdapter = tournamentRepositoryAdapter;
            _configuration = configuration;
        }
        public List<TournamentMatch> Create(string nom, IList<int> playerIds, IList<int> gameIds)
        {
            var tournamentMatches = new List<TournamentMatch>();
            List<Player> players = new List<Player>();
            foreach(int playerId in playerIds)
            {
                players.Add(new Player(new PlayerId(playerId), String.Empty, String.Empty, String.Empty));
            }
            List<Game> games = new List<Game>();
            foreach(int gameId in gameIds)
            {
                games.Add(new Game(new GameId(gameId), String.Empty));
            }
            foreach (var game in GetEvenlyDistributedGames(games, playerIds.Count))
            {
                foreach (var team in game.Teams)
                {
                    TournamentMatch tournamentMatch = new TournamentMatch(game);
                    foreach (var player in team.Players)
                    {
                        MatchScore matchScore = new MatchScore(players[player],0);
                        tournamentMatch.Scores.Add(matchScore);
                    }
                    tournamentMatches.Add(tournamentMatch);
                }
            }
            _repositoryAdapter.Create(nom, tournamentMatches);
            return tournamentMatches;
        }

        public List<TournamentMatch> GetAll()
        {
            return _repositoryAdapter.GetAll();
        }
        public IList<Game> GetEvenlyDistributedGames(IList<Game> games, int playerCount)
        {
            List<int> players = new List<int>();
            for (int playerIndex = 0; playerIndex < playerCount; playerIndex++)
                players.Add(playerIndex);

            int[] counter = new int[players.Count];
            PlayerMeeting playerMeetings = new PlayerMeeting(playerCount);

            int numberOfPlayersByTeam = int.Parse(_configuration["AppSettings:NumberOfPlayersByTeam"].ToString());
            BrowseGames(playerCount, games, counter, playerMeetings, numberOfPlayersByTeam);

            return games;
        }
        public async Task<Tournoi> Update(long id, string name, DateTime startDate, DateTime endDate)
        {
            return await _repositoryAdapter.Update(id, name, startDate, endDate);
        }
        /// <summary>
        /// Browse the games in a tournament
        /// </summary>
        /// <param name="playerCount">Number of players in the tournament</param>
        /// <param name="games">List of the games in the tournament</param>
        /// <param name="counter">Number of assignation in a team for each player</param>
        /// <param name="playersMeetings">Number of meetings between two players</param>
        /// <param name="numberOfPlayersByTeam">Number of players maximum by team</param>
        private void BrowseGames(int playerCount, IList<Game> games, int[] counter, PlayerMeeting playersMeetings, int numberOfPlayersByTeam)
        {
            foreach (Game game in games)
            {
                game.Teams = new List<Team>();
                BrowseTeams(playerCount, counter, playersMeetings, numberOfPlayersByTeam, game);
            }
        }
        /// <summary>
        /// Browse the teams in a game
        /// </summary>
        /// <param name="playerCount">Number of players in the tournament</param>
        /// <param name="counter">Number of assignation in a team for each player</param>
        /// <param name="playersMeetings">Number of assignation in a team for each player</param>
        /// <param name="numberOfPlayersByTeam">Number of players maximum by team</param>
        /// <param name="game"></param>
        /// <returns></returns>
        private void BrowseTeams(int playerCount, int[] counter, PlayerMeeting playersMeetings, int numberOfPlayersByTeam, Game game)
        {
            int attributedPlayers = 0;
            int numberOfTeams = (playerCount + numberOfPlayersByTeam - 1) / numberOfPlayersByTeam;
            for (int teamIndex = 0; teamIndex < numberOfTeams; teamIndex++)
            {
                Team team = new Team() { Players = new List<int>() };
                attributedPlayers = SetPlayersInTeam(playerCount, counter, playersMeetings, numberOfPlayersByTeam, attributedPlayers, team);
                game.Teams.Add(team);
            }
        }

        /// <summary>
        /// Attribute X number of players in a team
        /// </summary>
        /// <param name="playerCount">Number of players in the tournament</param>
        /// <param name="counter">Number of assignation in a team for each player</param>
        /// <param name="playersMeetings"></param>
        /// <param name="numberOfPlayersByTeam">Number of players maximum by team</param>
        /// <param name="attributedPlayers"></param>
        /// <param name="team"></param>
        /// <returns></returns>
        private static int SetPlayersInTeam(int playerCount, int[] counter, PlayerMeeting playersMeetings, int numberOfPlayersByTeam, int attributedPlayers, Team team)
        {
            for (int playerIndex = 0; playerIndex < numberOfPlayersByTeam; playerIndex++)
            {
                if (attributedPlayers < playerCount)
                {
                    int currentMinimumIndex = FilterPlayerMinList(SearchMinPlayerIndex(counter), playersMeetings, team);
                    team.Players.Add(currentMinimumIndex);
                    counter[currentMinimumIndex]++;
                    attributedPlayers++;
                    FeedNumberOfMeetingsBetweenTwoPlayers(currentMinimumIndex, playersMeetings, team);
                }
            }

            return attributedPlayers;
        }

        /// <summary>
        /// Feed the number of meetings between two players
        /// </summary>
        /// <param name="playersMeetings">Already initialized array of meetings between players</param>
        /// <param name="team"></param>
        private static void FeedNumberOfMeetingsBetweenTwoPlayers(int currentMinimumIndex, PlayerMeeting playersMeetings, Team team)
        {
            for (int playerIndex = 0; playerIndex < team.Players.Count; playerIndex++)
            {
                if (team.Players[playerIndex] != currentMinimumIndex)
                {
                    playersMeetings.IncrementMeetingsNumber(currentMinimumIndex, team.Players[playerIndex]);
                    playersMeetings.IncrementMeetingsNumber(team.Players[playerIndex], currentMinimumIndex);
                }
            }

        }

        /// <summary>
        /// Search for the first player who is the least distributed in the teams
        /// </summary>
        /// <param name="playCount">Donne le nombre de fois qu'un joueur est dans une team</param>
        /// <returns></returns>
        private static List<int> SearchMinPlayerIndex(int[] playCount)
        {
            int currentMinimumValue = int.MaxValue;
            for (int playerIndex = 0; playerIndex < playCount.Count(); playerIndex++)
            {
                if (currentMinimumValue > playCount[playerIndex])
                {
                    currentMinimumValue = playCount[playerIndex];
                }
            }
            List<int> playerWithSameMinimumValue = new List<int>();
            for (int playerIndex = 0; playerIndex < playCount.Count(); playerIndex++)
            {
                if (currentMinimumValue == playCount[playerIndex])
                {
                    playerWithSameMinimumValue.Add(playerIndex);
                }
            }
            return playerWithSameMinimumValue;
        }
        private static int FilterPlayerMinList(IList<int> playersMin, PlayerMeeting playerMeetings, Team team)
        {
            int currentMinimumValue = int.MaxValue;
            for (int playerIndex = 0; playerIndex < playersMin.Count; playerIndex++)
            {
                int player = playersMin[playerIndex];
                int maximum = playerMeetings.GetMeetingsMaximumNumber(player, team.Players);
                if (maximum != int.MinValue && currentMinimumValue > maximum)
                {
                    currentMinimumValue = maximum;
                }
            }
            if (currentMinimumValue == int.MaxValue)
            {
                return playersMin[0];
            }

            List<int> playerWithSameMinimumValue = new List<int>();
            for (int playerIndex = 0; playerIndex < playersMin.Count; playerIndex++)
            {
                int player = playersMin[playerIndex];
                int maximum = playerMeetings.GetMeetingsMaximumNumber(player, team.Players);
                if (currentMinimumValue == maximum)
                {
                    playerWithSameMinimumValue.Add(player);
                }
            }

            return playerWithSameMinimumValue[0];
        }

    }
}