using ClashRoyaleManager.Application.Repositories;
using FastEndpoints;
using FluentValidation;

namespace ClashRoyaleManager.Application.Commands.Admin.PlayerChallenge.Delete;

public class PlayerChallengeDeleteCommandValidator : Validator<PlayerChallengeDeleteCommand>
{
    public PlayerChallengeDeleteCommandValidator()
    {
        RuleFor(x => x.IdPlayer)
            .MustAsync(async (x, ct) =>
            {
                var scope = CreateScope();
                var playerRepo = scope.Resolve<IPlayerRepository>();

                var player = await playerRepo.Get(x);

                return player != null;
            }).WithMessage("This PlayerId does not exists");

        RuleFor(x => x.IdChallenge)
            .MustAsync(async (x, ct) =>
            {
                var scope = CreateScope();
                var challengeRepo = scope.Resolve<IChallengeRepository>();

                var challenge = await challengeRepo.Get(x);

                return challenge != null;
            }).WithMessage("This ChallengeId does not exists");
    }
}