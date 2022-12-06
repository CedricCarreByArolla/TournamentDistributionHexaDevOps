using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using TournamentDistributionHexa.Domain.Configuration.Data;
using TournamentDistributionHexa.Domain.Scores;
using TournamentDistributionHexa.Domain.Tournaments;
using TournamentDistributionHexa.Infrastructure.Database;
using TournamentDistributionHexa.Infrastructure.Models;
using TournamentDistributionHexa.Infrastructure.Repositories;

namespace TournamentDistributionHexa.Infrastructure
{
    public static class InfraServiceCollectionExtensions
    {
        public static IServiceCollection RegisterInfraServices(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddScoped<ITournamentMatchRepository, TournamentMatchRepositoryAdapter>();
            services.AddScoped<IScoreRepository, ScoreRepositoryAdapter>();
            services.AddSingleton<ISqlConnectionFactory>(new SqlConnectionFactory(configuration["ConnectionStrings:RepartitionTournoiContext"]));
            services.AddDbContext<RepartitionTournoiContext>(
                options => options.UseSqlServer("name=ConnectionStrings:RepartitionTournoiContext"));

            return services;
        }
    }
}
