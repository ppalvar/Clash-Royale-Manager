using ClashRoyaleManager.Application.Repositories;
using FastEndpoints;

namespace ClashRoyaleManager.Application.Commands.Admin.PlayerClan.Delete;

public class PlayerClanDeleteCommandHandler(IPlayerClanRepository _playerClanRepository) : CommandHandler<PlayerClanDeleteCommand, Domain.Entities.PlayerClan>
{
    public override async Task<Domain.Entities.PlayerClan> ExecuteAsync(PlayerClanDeleteCommand command, CancellationToken ct = default)
    {
        return await _playerClanRepository.Remove(command.IdPlayer, command.IdClan);
    }
}