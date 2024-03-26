using FastEndpoints;
using FluentValidation;

namespace ClashRoyaleManager.Application.Commands.Admin.UpdateChallenge;

public class UpdateChallengeCommandValidator : Validator<UpdateChallengeCommand>
{
    public UpdateChallengeCommandValidator()
    {
        RuleFor(x => x.Name)
            .MinimumLength(3).MaximumLength(10).WithMessage("The Name must have 3-10 characters");
        
        RuleFor(x => x.Description)
            .MinimumLength(7).MaximumLength(100).WithMessage("The Description must have 7-100 characters");

        RuleFor(x => x.Cost)
            .GreaterThanOrEqualTo(0).WithMessage("The Cost must be greater than or equal to 0");

        RuleFor(x => x.NumberOfPrizes)
            .GreaterThanOrEqualTo(0).WithMessage("The NumberOfPrizes must be greater than or equal to 0");

        RuleFor(x => x.NumberOfAdmissibleDefeats)
            .GreaterThanOrEqualTo(0).WithMessage("The NumberOfAdmissibleDefeats must be greater than or equal to 0");

        RuleFor(x => x.Duration)
            .GreaterThanOrEqualTo(0).WithMessage("The Duration must be greater than or equal to 0");

        RuleFor(x => x.MaximumLevel)
            .GreaterThanOrEqualTo(0).WithMessage("The MaximumLevel must be greater than or equal to 0");

    }
}