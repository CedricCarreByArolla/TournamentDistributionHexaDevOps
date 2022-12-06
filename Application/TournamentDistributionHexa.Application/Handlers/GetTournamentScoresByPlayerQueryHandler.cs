using Dapper;
using MediatR;
using TournamentDistributionHexa.Application.Models.Requests;
using TournamentDistributionHexa.Application.Queries;
using TournamentDistributionHexa.Domain.Configuration.Data;

namespace TournamentDistributionHexa.Application.Handlers
{
    public class GetTournamentScoresByPlayerQueryHandler : IRequestHandler<GetTournamentScoresByPlayerQuery, IEnumerable<GetScoreResponse>>
    {
        private readonly ISqlConnectionFactory _sqlConnectionFactory;

        public GetTournamentScoresByPlayerQueryHandler(ISqlConnectionFactory sqlConnectionFactory)
        {
            _sqlConnectionFactory = sqlConnectionFactory;
        }

        public async Task<IEnumerable<GetScoreResponse>> Handle(GetTournamentScoresByPlayerQuery request, CancellationToken cancellationToken)
        {
            List<GetScoreResponse> getScoreResponses = new List<GetScoreResponse>();
            var connection = _sqlConnectionFactory.GetOpenConnection();
            const string sql = @"SELECT 
                                s.[JoueurId],
                                s.[Points], 
                                s.[MatchId], 
                                m.[Id] as MatchId, 
                                m.[Nom] as MatchNom, 
                                m.[DateFin], 
                                j.[Id] as JoueurId, 
                                j.[Nom] as JoueurNom, 
                                j.[Prenom], 
                                j.[Telephone],
                                jeu.[Id] as JeuId,
                                jeu.[Nom] as JeuNom
                                FROM [dbo].[Score] AS s 
                                INNER JOIN [dbo].[Match] as m ON s.MatchId = m.Id 
                                INNER JOIN [dbo].[Joueur] as j ON j.Id = s.JoueurId 
                                INNER JOIN [dbo].[Composition] as c ON c.MatchId = m.Id 
                                INNER JOIN [dbo].[Jeu] as jeu ON jeu.Id = c.JeuId
                               WHERE c.TournoiId = @TournamentId
                                AND j.Id = @PlayerId";
            foreach (var line in await connection.QueryAsync(sql, new { request.TournamentId, request.PlayerId }))
            {
                GetGameResponse getGameResponse = new GetGameResponse((long)line.JeuId, (string)line.JeuNom);
                GetMatchResponse getMatchResponse = new GetMatchResponse((long)line.MatchId, (string)line.MatchNom, (DateTime?)line.DateFin);
                GetPlayerResponse getPlayerResponse = new GetPlayerResponse((long)line.JoueurId, (string)line.JoueurNom, (string)line.Prenom, (string)line.Telephone);
                getScoreResponses.Add(new GetScoreResponse(getMatchResponse, getPlayerResponse, getGameResponse, (int)line.Points));
            }
            return getScoreResponses;
        }
    }
}
