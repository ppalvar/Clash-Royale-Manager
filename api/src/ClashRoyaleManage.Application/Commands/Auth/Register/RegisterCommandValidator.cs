using FastEndpoints;
using FluentValidation;

namespace ClashRoyaleManager.Application.Commands.Auth;

public class RegisterCommandValidator : Validator<RegisterCommand>
{
    public RegisterCommandValidator()
    {
        RuleFor(x => x.Password)
            .MinimumLength(6).WithMessage("The password must have at least 6 characters");
        
        RuleFor(x => x.Username)
            .MinimumLength(3).MaximumLength(10).WithMessage("The username must have 3-10 characters");
        
        RuleFor(x => x.Email)
            .EmailAddress().WithMessage("The Email provided is not valid");
    }
}