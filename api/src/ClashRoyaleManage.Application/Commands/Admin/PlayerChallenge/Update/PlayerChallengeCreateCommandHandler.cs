using ClashRoyaleManager.Application.Repositories;
using FastEndpoints;

namespace ClashRoyaleManager.Application.Commands.Admin.PlayerChallenge.Update;

public class PlayerChallengeUpdateCommandHandler(IPlayerChallengeRepository _playerChallengeRepository) : CommandHandler<PlayerChallengeUpdateCommand, Domain.Entities.PlayerChallenge>
{
    public override async Task<Domain.Entities.PlayerChallenge> ExecuteAsync(PlayerChallengeUpdateCommand command, CancellationToken ct = default)
    {
        var playerChallenge = new Domain.Entities.PlayerChallenge
        {
            IdChallenge = command.IdChallenge,
            IdPlayer = command.IdPlayer
        };

        await _playerChallengeRepository.Update(playerChallenge);

        return playerChallenge;
    }
}