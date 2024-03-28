using ClashRoyaleManager.Application.Query.Cards;
using ClashRoyaleManager.Application.Repositories;
using FastEndpoints;
using FluentValidation;

namespace ClashRoyaleManager.Application.Query.Players;

public class MostPopularInClanQueryValidator : Validator<MostPopularInClanQuery>
{
    public MostPopularInClanQueryValidator()
    {
        RuleFor(x => x.ClanId)
            .NotEmpty().WithMessage("ClanId must not be empty")
            .NotNull().WithMessage("ClanId must not be null")
            .MustAsync(async (x, ct) =>
            {
                var scope = CreateScope();
                var _clanRepo = scope.Resolve<IClanRepository>();

                return await _clanRepo.Get(x) != null;
            }).WithMessage(x => $"There is no war with Id <{x.ClanId}>");

        RuleFor(x => x.Page)
            .NotNull()
            .GreaterThan(0).WithMessage("Page must be a positive integer");

        RuleFor(x => x.PageSize)
            .NotNull()
            .GreaterThan(0).WithMessage("Page size must be a positive integer");
    }
}