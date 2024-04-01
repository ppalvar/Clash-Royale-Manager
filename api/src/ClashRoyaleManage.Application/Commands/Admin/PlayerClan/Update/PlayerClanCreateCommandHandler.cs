using ClashRoyaleManager.Application.Repositories;
using FastEndpoints;

namespace ClashRoyaleManager.Application.Commands.Admin.PlayerClan.Update;

public class PlayerClanUpdateCommandHandler(IPlayerClanRepository _playerClanRepository) : CommandHandler<PlayerClanUpdateCommand, Domain.Entities.PlayerClan>
{
    public override async Task<Domain.Entities.PlayerClan> ExecuteAsync(PlayerClanUpdateCommand command, CancellationToken ct = default)
    {
        var playerClan = new Domain.Entities.PlayerClan
        {
            IdClan = command.IdClan,
            IdPlayer = command.IdPlayer
        };

        await _playerClanRepository.Update(playerClan);

        return playerClan;
    }
}