using FastEndpoints;
using FluentValidation;

namespace ClashRoyaleManager.Application.Commands.Admin.CreateStructureCard;

public class CreateStructureCardCommandValidator : Validator<CreateStructureCardCommand>
{
    public CreateStructureCardCommandValidator()
    {
        RuleFor(x => x.LifePoints)
            .GreaterThanOrEqualTo(0).WithMessage("The life points must be greater than or equal to 0");

        
    }
}