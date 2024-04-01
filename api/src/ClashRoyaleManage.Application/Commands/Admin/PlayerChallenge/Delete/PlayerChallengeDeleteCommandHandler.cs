using ClashRoyaleManager.Application.Repositories;
using FastEndpoints;

namespace ClashRoyaleManager.Application.Commands.Admin.PlayerChallenge.Delete;

public class PlayerChallengeDeleteCommandHandler(IPlayerChallengeRepository _playerChallengeRepository) : CommandHandler<PlayerChallengeDeleteCommand, Domain.Entities.PlayerChallenge>
{
    public override async Task<Domain.Entities.PlayerChallenge> ExecuteAsync(PlayerChallengeDeleteCommand command, CancellationToken ct = default)
    {
        return await _playerChallengeRepository.Remove(command.IdPlayer, command.IdChallenge);
    }
}