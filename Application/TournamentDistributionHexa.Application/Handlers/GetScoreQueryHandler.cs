using Dapper;
using MediatR;
using TournamentDistributionHexa.Application.Queries;
using TournamentDistributionHexa.Domain.Configuration.Data;
using TournamentDistributionHexa.Domain.Scores;

namespace TournamentDistributionHexa.Application.Handlers
{
    public class GetScoreQueryHandler : IRequestHandler<GetScoreQuery, Score>
    {
        private readonly ISqlConnectionFactory _sqlConnectionFactory;

        public GetScoreQueryHandler(ISqlConnectionFactory sqlConnectionFactory)
        {
            this._sqlConnectionFactory = sqlConnectionFactory;
        }

        public async Task<Score> Handle(GetScoreQuery request, CancellationToken cancellationToken)
        {
            var connection = this._sqlConnectionFactory.GetOpenConnection();
            const string sql = "SELECT " +
                               "s.[MatchId], " +
                               "s.[JoueurId], " +
                               "s.[Points]"+
                               "FROM [dbo].[Score] AS s";
            return await connection.QueryFirstAsync<Score>(sql);
        }
    }
}
