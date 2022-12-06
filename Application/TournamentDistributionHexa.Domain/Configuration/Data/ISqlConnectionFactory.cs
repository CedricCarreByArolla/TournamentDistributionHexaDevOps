using System.Data;

namespace TournamentDistributionHexa.Domain.Configuration.Data
{
    public interface ISqlConnectionFactory
    {
        IDbConnection GetOpenConnection();
    }
}
