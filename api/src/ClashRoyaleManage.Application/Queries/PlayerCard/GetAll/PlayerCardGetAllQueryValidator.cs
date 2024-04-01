using FastEndpoints;
using FluentValidation;

namespace ClashRoyaleManager.Application.Queries.PlayerCard.GetAll;

public class PlayerCardGetAllQueryValidator : Validator<PlayerCardGetAllQuery>
{
    public PlayerCardGetAllQueryValidator()
    {
        RuleFor(x => x.Page)
            .GreaterThan(0).WithMessage("The Page must be a positive integer");
        RuleFor(x => x.PageSize)
            .GreaterThan(0).WithMessage("The Page Size must be a positive integer");
    }
}