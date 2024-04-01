using FastEndpoints;
using FluentValidation;

namespace ClashRoyaleManager.Application.Queries.PlayerClan.GetAll;

public class GetAllPlayerClansQueryValidator : Validator<GetAllPlayerClanQuery>
{
    public GetAllPlayerClansQueryValidator()
    {
        RuleFor(x => x.Page)
            .GreaterThan(0).WithMessage("The Page must be a positive integer");
        RuleFor(x => x.PageSize)
            .GreaterThan(0).WithMessage("The Page Size must be a positive integer");
    }
}