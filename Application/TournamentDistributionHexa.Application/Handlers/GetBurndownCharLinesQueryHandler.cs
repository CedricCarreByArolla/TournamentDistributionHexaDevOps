using Dapper;
using MediatR;
using System.Globalization;
using TournamentDistributionHexa.Application.Models.Requests;
using TournamentDistributionHexa.Application.Models.Responses;
using TournamentDistributionHexa.Application.Queries;
using TournamentDistributionHexa.Domain.Configuration.Data;
using TournamentDistributionHexa.Domain.Tournaments;

namespace TournamentDistributionHexa.Application.Handlers
{
    public class GetBurndownCharLinesQueryHandler : IRequestHandler<GetBurndownChartsQuery, IEnumerable<GetBurndownChartLineResponse>>
    {

        private readonly ISqlConnectionFactory _sqlConnectionFactory;
        private readonly ITournamentMatchRepository _matchRepository;

        public GetBurndownCharLinesQueryHandler(ISqlConnectionFactory sqlConnectionFactory, ITournamentMatchRepository tournamentMatchRepository)
        {
            this._sqlConnectionFactory = sqlConnectionFactory;
            this._matchRepository = tournamentMatchRepository;  
        }
        public async Task<IEnumerable<GetBurndownChartLineResponse>> Handle(GetBurndownChartsQuery request, CancellationToken cancellationToken)
        {
            return await GetBurndownChartLineDTOs(request.TournamentId);
        }
        private async Task<IEnumerable<GetBurndownChartLineResponse>> GetBurndownChartLineDTOs(long tournamentId)
        {
            List<GetBurndownChartLineResponse> lines = await InitializeBurndownChartLines(tournamentId);
            Dictionary<int, int> weekFinishedMatches = new Dictionary<int, int>();
            foreach (var match in await GetFinishedMatchsOfTournament(tournamentId))
            {
                int weekNumber = CultureInfo.InvariantCulture.Calendar.GetWeekOfYear((DateTime)match.EndDate, CalendarWeekRule.FirstFourDayWeek, DayOfWeek.Monday);
                if (weekFinishedMatches.ContainsKey(weekNumber))
                {
                    weekFinishedMatches[weekNumber]++;
                }
                else
                {
                    weekFinishedMatches.Add(weekNumber, 1);
                }
            }
            weekFinishedMatches = weekFinishedMatches.OrderBy(x => x.Key).ToDictionary(x => x.Key, x => x.Value);

            for (int i = weekFinishedMatches.First().Key; i < (weekFinishedMatches.First().Key + weekFinishedMatches.Count - 1); i++)
            {
                weekFinishedMatches[i + 1] += weekFinishedMatches[i];
            }
            foreach (var line in lines)
            {
                foreach (var weekFinishedMatch in weekFinishedMatches)
                {
                    if (line.weekNumber == weekFinishedMatch.Key)
                    {
                        line.actual = await GetNumberOfMatchesInTournament(tournamentId) - weekFinishedMatch.Value;
                    }
                }
            }
            return lines;
        }

        private async Task<IEnumerable<GetMatchResponse>> GetFinishedMatchsOfTournament(long tournamentId)
        {
            var connection = _sqlConnectionFactory.GetOpenConnection();
            const string sql = @"SELECT m.id as MatchId, m.DateFin as EndDate 
                                from composition c
                                inner join match m on m.id = c.matchid
                                where c.tournoiid = @TournamentId
                                and m.DateFin IS NOT NULL";
            return await connection.QueryAsync<GetMatchResponse>(sql, new {TournamentId = tournamentId});
        }
        private async Task<GetTournamentResponse> GetTournamentById(long tournamentId)
        {
            var connection = _sqlConnectionFactory.GetOpenConnection();
            const string sql = @"SELECT * 
                                from tournoi t
                                where t.id = @TournamentId";
            return await connection.QueryFirstAsync<GetTournamentResponse>(sql, new { TournamentId = tournamentId });
        }

        public async Task<List<GetBurndownChartLineResponse>> InitializeBurndownChartLines(long tournamentId)
        {
            var list = new List<GetBurndownChartLineResponse>();
            var tournoi = await GetTournamentById(tournamentId);
            if (tournoi == null || tournoi.StartDate == null || tournoi.EndDate == null)
            {
                throw new ArgumentNullException("Tournoi, DateDebut ou DateFin sont vides");
            }
            DateTime dateDebut = (DateTime)tournoi.StartDate;
            DateTime dateFin = (DateTime)tournoi.EndDate;
            int numberOfMatchs = await GetNumberOfMatchesInTournament(tournamentId);
            int numberOfGames = await GetNumberOfGamesInTournament(tournamentId);
            int numberOfMatchsByGame = numberOfMatchs / numberOfGames;
            do
            {
                if (dateDebut.DayOfWeek == DayOfWeek.Monday)
                {
                    int weekNumber = CultureInfo.InvariantCulture.Calendar.GetWeekOfYear(dateDebut, CalendarWeekRule.FirstFourDayWeek, DayOfWeek.Monday);
                    list.Add(new GetBurndownChartLineResponse($"{dateDebut.Year} W{weekNumber}", numberOfMatchs, weekNumber));
                    numberOfMatchs -= numberOfMatchsByGame;
                }
                dateDebut = dateDebut.AddDays(1);
            }
            while (!dateDebut.Date.Equals(dateFin.Date));
            return list;
        }
        private async Task<int> GetNumberOfMatchesInTournament(long tournamentId)
        {
            var connection = _sqlConnectionFactory.GetOpenConnection();
            const string sql = @"SELECT COUNT(*) 
                                FROM [dbo].[Composition] AS c
                                WHERE c.TournoiId = @TournamentId";

            return await connection.QueryFirstAsync<int>(sql, new { tournamentId });
        }
        private async Task<int> GetNumberOfGamesInTournament(long tournamentId)
        {
            var connection = _sqlConnectionFactory.GetOpenConnection();
            const string sql = @"SELECT COUNT(DISTINCT(JeuId)) 
                                FROM [dbo].[Composition] AS c
                                WHERE c.TournoiId = @TournamentId";

            return await connection.QueryFirstAsync<int>(sql, new { tournamentId });
        }
    }
}
