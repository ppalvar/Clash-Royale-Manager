using FastEndpoints;
using FluentValidation;

namespace ClashRoyaleManager.Application.Commands.Admin.CreateClan;

public class CreateClanCommandValidator : Validator<CreateClanCommand>
{
    public CreateClanCommandValidator()
    {
        RuleFor(x => x.Name)
            .MinimumLength(3).MaximumLength(10).WithMessage("The Name must have 3-10 characters");

        RuleFor(x => x.Description)
            .MinimumLength(7).MaximumLength(100).WithMessage("The Description must have 7-100 characters");

        RuleFor(x => x.NumberOfTrophiesObtainedInWars)
            .GreaterThanOrEqualTo(0).WithMessage("The Number of trophies obtained in wars must be greater than or equal to 0");

        RuleFor(x => x.NumberOfMembers)
            .GreaterThanOrEqualTo(0).WithMessage("The number of members must be greater than or equal to 0");

        RuleFor(x => x.TrophiesNeededToEnter)
            .GreaterThanOrEqualTo(0).WithMessage("The trophies needed to enter must be greater than or equal to 0");

    }
}