using ClashRoyaleManager.Application.Repositories;
using FastEndpoints;
using FluentValidation;

namespace ClashRoyaleManager.Application.Query.Players;

public class ListBestPlayersInWarQueryValidator : Validator<ListBestPlayersInWarQuery>
{
    public ListBestPlayersInWarQueryValidator()
    {
        RuleFor(x => x.WarId)
            .NotEmpty().WithMessage("WarId must not be empty")
            .NotNull().WithMessage("WarId must not be null")
            .MustAsync(async (x, ct) =>
            {
                var scope = CreateScope();
                var _warRepo = scope.Resolve<IWarRepository>();

                return await _warRepo.Get(x) != null;
            }).WithMessage(x => $"There is no war with Id <{x.WarId}>");

        RuleFor(x => x.Page)
            .NotNull()
            .GreaterThan(0).WithMessage("Page must be a positive integer");

        RuleFor(x => x.PageSize)
            .NotNull()
            .GreaterThan(0).WithMessage("Page size must be a positive integer");
    }
}