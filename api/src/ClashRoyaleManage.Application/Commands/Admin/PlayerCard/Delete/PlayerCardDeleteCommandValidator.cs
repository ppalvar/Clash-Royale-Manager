using ClashRoyaleManager.Application.Repositories;
using FastEndpoints;
using FluentValidation;

namespace ClashRoyaleManager.Application.Commands.Admin.PlayerCard.Delete;

public class PlayerCardDeleteCommandValidator : Validator<PlayerCardDeleteCommand>
{
    public PlayerCardDeleteCommandValidator()
    {
        RuleFor(x => x.PlayerId)
            .MustAsync(async (x, ct) =>
            {
                var scope = CreateScope();
                var clanRepo = scope.Resolve<IPlayerRepository>();

                var player = await clanRepo.Get(x);

                return player != null;
            }).WithMessage("This PlayerId does not exists");

        RuleFor(x => x.CardId)
            .MustAsync(async (x, ct) =>
            {
                var scope = CreateScope();
                var cardRepo = scope.Resolve<IWarRepository>();

                var card = await cardRepo.Get(x);

                return card != null;
            }).WithMessage("This CardId does not exists");
    }
}