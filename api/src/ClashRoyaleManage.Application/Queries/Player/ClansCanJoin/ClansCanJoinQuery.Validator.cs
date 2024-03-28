using ClashRoyaleManager.Application.Query.Players;
using ClashRoyaleManager.Application.Repositories;
using FastEndpoints;
using FluentValidation;

namespace ClashRoyaleManager.Application.Query;

public class ClansCanJoinQueryValidator : Validator<ClansCanJoinQuery>
{
    public ClansCanJoinQueryValidator()
    {
        RuleFor(x => x.PlayerId)
            .NotEmpty().WithMessage("PlayerId must not be empty")
            .NotNull().WithMessage("PlayerId must not be null")
            .MustAsync(async (x, ct) =>
            {
                var scope = CreateScope();
                var _warRepo = scope.Resolve<IPlayerRepository>();

                return await _warRepo.Get(x) != null;
            }).WithMessage(x => $"There is no war with Id <{x.PlayerId}>");

        RuleFor(x => x.Page)
            .NotNull()
            .GreaterThan(0).WithMessage("Page must be a positive integer");

        RuleFor(x => x.PageSize)
            .NotNull()
            .GreaterThan(0).WithMessage("Page size must be a positive integer");
    }
}