using FastEndpoints;
using FluentValidation;

namespace ClashRoyaleManager.Application.Commands.Admin.CreateSpellCard;

public class CreateSpellCardCommandValidator : Validator<CreateSpellCardCommand>
{
    public CreateSpellCardCommandValidator()
    {
        RuleFor(x => x.Radio)
            .GreaterThanOrEqualTo(0).WithMessage("The radio must be greater than or equal to 0");

        RuleFor(x => x.Duration)
            .GreaterThanOrEqualTo(0).WithMessage("The duration must be greater than or equal to 0");

        RuleFor(x => x.DamageToTowers)
            .GreaterThanOrEqualTo(0).WithMessage("The damage to towers must be greater than or equal to 0");

        RuleFor(x => x.DamageInArea)
            .GreaterThanOrEqualTo(0).WithMessage("The damage in area must be greater than or equal to 0");

    }
}