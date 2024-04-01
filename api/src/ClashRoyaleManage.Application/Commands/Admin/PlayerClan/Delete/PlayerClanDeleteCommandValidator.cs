using ClashRoyaleManager.Application.Repositories;
using FastEndpoints;
using FluentValidation;

namespace ClashRoyaleManager.Application.Commands.Admin.PlayerClan.Delete;

public class PlayerClanDeleteCommandValidator : Validator<PlayerClanDeleteCommand>
{
    public PlayerClanDeleteCommandValidator()
    {
        RuleFor(x => x.IdPlayer)
            .MustAsync(async (x, ct) =>
            {
                var scope = CreateScope();
                var playerRepo = scope.Resolve<IPlayerRepository>();

                var player = await playerRepo.Get(x);

                return player != null;
            }).WithMessage("This PlayerId does not exists");

        RuleFor(x => x.IdClan)
            .MustAsync(async (x, ct) =>
            {
                var scope = CreateScope();
                var clanRepo = scope.Resolve<IClanRepository>();

                var clan = await clanRepo.Get(x);

                return clan != null;
            }).WithMessage("This ClanId does not exists");
    }
}