using ClashRoyaleManager.Application.Repositories;
using FastEndpoints;

namespace ClashRoyaleManager.Application.Commands.Admin.PlayerChallenge.Create;

public class PlayerChallengeCreateCommandHandler(IPlayerChallengeRepository _playerChallengeRepository) : CommandHandler<PlayerChallengeCreateCommand, Domain.Entities.PlayerChallenge>
{
    public override async Task<Domain.Entities.PlayerChallenge> ExecuteAsync(PlayerChallengeCreateCommand command, CancellationToken ct = default)
    {
        var playerChallenge = new Domain.Entities.PlayerChallenge
        {
            IdChallenge = command.IdChallenge,
            IdPlayer = command.IdPlayer
        };

        await _playerChallengeRepository.Create(playerChallenge);

        return playerChallenge;
    }
}