using ClashRoyaleManager.Application.Repositories;
using FastEndpoints;
using FluentValidation;

namespace ClashRoyaleManager.Application.Commands.Admin.ClanWar.Update;

public class ClanWarUpdateCommandValidator : Validator<ClanWarUpdateCommand>
{
    public ClanWarUpdateCommandValidator()
    {
        RuleFor(x => x.ClanId)
            .MustAsync(async (x, ct) =>
            {
                var scope = CreateScope();
                var clanRepo = scope.Resolve<IClanRepository>();

                var clan = await clanRepo.Get(x);

                return clan != null;
            }).WithMessage("This ClanId does not exists");

        RuleFor(x => x.WarId)
            .MustAsync(async (x, ct) =>
            {
                var scope = CreateScope();
                var warRepo = scope.Resolve<IWarRepository>();

                var war = await warRepo.Get(x);

                return war != null;
            }).WithMessage("This WarId does not exists");
    }
}