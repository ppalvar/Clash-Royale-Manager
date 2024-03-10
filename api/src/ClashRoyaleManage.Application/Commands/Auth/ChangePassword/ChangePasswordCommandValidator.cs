using ClashRoyaleManager.Application.Repositories;
using FastEndpoints;
using FluentValidation;

namespace ClashRoyaleManager.Application.Commands.Auth;

public class ChangePasswordCommandValidator : Validator<ChangePasswordCommand>
{
    public ChangePasswordCommandValidator(IUserRepository repository)
    {
        RuleFor(x => x.NewPassword)
            .NotEmpty().WithMessage("The password is required.")
            .MinimumLength(6).WithMessage("The password must have at least 6 characters.");
    }
}