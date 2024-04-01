using FastEndpoints;
using FluentValidation;

namespace ClashRoyaleManager.Application.Queries.ClanWar.GetAll;

public class GetAllClanWarsQueryValidator : Validator<GetAllClanWarsQuery>
{
    public GetAllClanWarsQueryValidator()
    {
        RuleFor(x => x.Page)
            .GreaterThan(0).WithMessage("The Page must be a positive integer");
        RuleFor(x => x.PageSize)
            .GreaterThan(0).WithMessage("The Page Size must be a positive integer");
    }
}