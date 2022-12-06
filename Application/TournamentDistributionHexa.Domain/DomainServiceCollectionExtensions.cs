using Microsoft.Extensions.DependencyInjection;
using TournamentDistributionHexa.Domain.Repositories;
using TournamentDistributionHexa.Domain.Scores;

namespace TournamentDistributionHexa.Domain
{
    public static class DomainServiceCollectionExtensions
    {
        public static IServiceCollection RegisterDomainServices(this IServiceCollection services)
        {
            services.AddScoped<ITournamentDomain, TournamentDomain>();
            services.AddScoped<IScoreDomain, ScoreDomain>();
            return services;
        }
    }
}
