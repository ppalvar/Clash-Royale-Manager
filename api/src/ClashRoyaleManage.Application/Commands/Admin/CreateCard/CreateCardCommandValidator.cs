using FastEndpoints;
using FluentValidation;

namespace ClashRoyaleManager.Application.Commands.Admin.CreateCard;

public class CretaeCardCommandValidator : Validator<CreateCardCommand>
{
    public CretaeCardCommandValidator()
    {
        RuleFor(x => x.Name)
            .MinimumLength(3).MaximumLength(10).WithMessage("The Name must have 3-10 characters");
        
        RuleFor(x => x.Description)
            .MinimumLength(14).MaximumLength(40).WithMessage("The description must have 14-40 characteres");
    }
}