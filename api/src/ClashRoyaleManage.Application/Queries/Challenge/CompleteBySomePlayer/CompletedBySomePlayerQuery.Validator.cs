using ClashRoyaleManager.Application.Query.Challenges;
using ClashRoyaleManager.Application.Query.Players;
using ClashRoyaleManager.Application.Repositories;
using FastEndpoints;
using FluentValidation;

namespace ClashRoyaleManager.Application.Query;

public class CompletedBySomePlayerQueryValidator : Validator<CompletedBySomePlayerQuery>
{
    public CompletedBySomePlayerQueryValidator()
    {
        RuleFor(x => x.Page)
            .NotNull()
            .GreaterThan(0).WithMessage("Page must be a positive integer");

        RuleFor(x => x.PageSize)
            .NotNull()
            .GreaterThan(0).WithMessage("Page size must be a positive integer");
    }
}