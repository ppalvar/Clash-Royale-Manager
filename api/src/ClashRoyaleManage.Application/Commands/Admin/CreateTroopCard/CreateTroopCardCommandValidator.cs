using FastEndpoints;
using FluentValidation;

namespace ClashRoyaleManager.Application.Commands.Admin.CreateTroopCard;

public class CreateTroopCardCommandValidator : Validator<CreateTroopCardCommand>
{
    public CreateTroopCardCommandValidator()
    {
        RuleFor(x => x.LifePoints)
            .GreaterThanOrEqualTo(0).WithMessage("The life points must be greater than or equal to 0");

        RuleFor(x => x.DamageInArea)
            .GreaterThanOrEqualTo(0).WithMessage("The damage in area must be greater than or equal to 0");
        RuleFor(x => x.NumberOfUnits)
            .GreaterThanOrEqualTo(0).WithMessage("The number of units must be greater than or equal to 0");

    }
}