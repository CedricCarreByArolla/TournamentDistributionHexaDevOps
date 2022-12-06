using FluentValidation;
using TournamentDistributionHexa.Application.Commands;
using TournamentDistributionHexa.Application.Models;

namespace TournamentDistributionHexa.Application.Validators
{
    public class CreateTournamentValidator : AbstractValidator<CreateTournamentCommand>
    {
        public CreateTournamentValidator()
        {
            RuleFor(x => x.Name).NotEmpty().WithMessage("A tournament must have a name.");
            RuleFor(x => x.StartDate).LessThan(x => x.EndDate).WithMessage("StartDate must be less than EndDate");
        }
    }
}
