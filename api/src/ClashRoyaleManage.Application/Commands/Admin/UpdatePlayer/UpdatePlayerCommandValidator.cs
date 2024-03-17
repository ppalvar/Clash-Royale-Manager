using FastEndpoints;
using FluentValidation;

namespace ClashRoyaleManager.Application.Commands.Admin.UpdatePlayer;

public class UpdatePlayerCommandValidator : Validator<UpdatePlayerCommand>
{
    public UpdatePlayerCommandValidator()
    {
        RuleFor(x => x.Nickname)
            .MinimumLength(3).MaximumLength(10).WithMessage("The Name must have 3-10 characters");
    }
}