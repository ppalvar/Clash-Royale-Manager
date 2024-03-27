using ClashRoyaleManager.Domain.Entities;
using FastEndpoints;
using FluentValidation;

namespace ClashRoyaleManager.Application.Query.Cards;

public class MostDonatedCardInRegionQueryValidator : Validator<MostDonatedCardInRegionQuery>
{
    public MostDonatedCardInRegionQueryValidator()
    {
        RuleFor(x => x.Region)
            .NotEmpty().NotNull().WithMessage("Region not provided");
    }
}