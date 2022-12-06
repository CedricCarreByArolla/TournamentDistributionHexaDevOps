using Dapper;
using MediatR;
using TournamentDistributionHexa.Application.Models.Requests;
using TournamentDistributionHexa.Application.Queries;
using TournamentDistributionHexa.Domain.Configuration.Data;

namespace TournamentDistributionHexa.Application.Handlers
{
    public class GetAllTournamentsQueryHandler : IRequestHandler<GetAllTournamentsQuery, IEnumerable<GetTournamentResponse>>
    {
        private readonly ISqlConnectionFactory _sqlConnectionFactory;

        public GetAllTournamentsQueryHandler(ISqlConnectionFactory sqlConnectionFactory)
        {
            _sqlConnectionFactory = sqlConnectionFactory;
        }

        public async Task<IEnumerable<GetTournamentResponse>> Handle(GetAllTournamentsQuery request, CancellationToken cancellationToken)
        {
            var connection = _sqlConnectionFactory.GetOpenConnection();
            const string sql = @"SELECT 
                                t.[Id], 
                                t.[Nom] as Name, 
                                t.[DateDebut] as StartDate, 
                                t.[DateFin] as EndDate
                                FROM [dbo].[Tournoi] AS t";
            return await connection.QueryAsync<GetTournamentResponse>(sql);
        }
    }
}
