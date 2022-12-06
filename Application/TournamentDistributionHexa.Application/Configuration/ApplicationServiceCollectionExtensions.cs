using FluentValidation;
using MediatR;
using System.Reflection;
using TournamentDistributionHexa.Application.Configuration.Middleware;
using TournamentDistributionHexa.Application.Handlers;
using TournamentDistributionHexa.Application.Models.Requests;
using TournamentDistributionHexa.Application.Queries;
using TournamentDistributionHexa.Domain.Scores;

namespace TournamentDistributionHexa.Application.Configuration
{
    public static class ApplicationServiceCollectionExtensions
    {
        public static IServiceCollection RegisterRequestHandlers(this IServiceCollection services)
        {
            return services.AddMediatR(Assembly.GetExecutingAssembly())
                .AddTransient(typeof(IPipelineBehavior<,>), typeof(ValidationBehavior<,>))
                .AddTransient<ExceptionHandlingMiddleware>()
                .AddValidatorsFromAssembly(Assembly.GetExecutingAssembly())
                .AddSingleton<IRequestHandler<GetAllTournamentsQuery, IEnumerable<GetTournamentResponse>>, GetAllTournamentsQueryHandler>()
                .AddSingleton<IRequestHandler<GetTournamentScoresQuery, IEnumerable<GetScoreResponse>>,GetTournamentScoresQueryHandler>()
                .AddSingleton<IRequestHandler<GetScoreQuery, Score>, GetScoreQueryHandler>(); 

        }
    }
}
