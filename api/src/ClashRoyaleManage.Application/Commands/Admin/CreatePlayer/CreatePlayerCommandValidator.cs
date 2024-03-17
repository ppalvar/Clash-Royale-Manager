using FastEndpoints;
using FluentValidation;

namespace ClashRoyaleManager.Application.Commands.Admin.CreatePlayer;

public class CreatePlayerCommandValidator : Validator<CreatePlayerCommand>
{
    public CreatePlayerCommandValidator()
    {
        RuleFor(x => x.Nickname)
            .MinimumLength(3).MaximumLength(10).WithMessage("The Nickname must have 3-10 characters");
    }
}