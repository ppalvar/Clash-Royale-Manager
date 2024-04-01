using ClashRoyaleManager.Application.Repositories;
using FastEndpoints;

namespace ClashRoyaleManager.Application.Commands.Admin.PlayerClan.Create;

public class PlayerClanCreateCommandHandler(IPlayerClanRepository _playerClanRepository) : CommandHandler<PlayerClansCreateCommand, Domain.Entities.PlayerClan>
{
    public override async Task<Domain.Entities.PlayerClan> ExecuteAsync(PlayerClansCreateCommand command, CancellationToken ct = default)
    {
        var playerClan = new Domain.Entities.PlayerClan
        {
            IdClan = command.IdClan,
            IdPlayer = command.IdPlayer
        };

        await _playerClanRepository.Create(playerClan);

        return playerClan;
    }
}