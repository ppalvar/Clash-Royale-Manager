using ClashRoyaleManager.Application.Repositories;
using ClashRoyaleManager.Application.Services;
using ClashRoyaleManager.Domain.Entities;
using FastEndpoints;

namespace ClashRoyaleManager.Application.Commands.Admin.PlayerCard.Delete;

public class PlayerCardDeleteCommandHandler(IPlayerCardRepository _clanWarRepository) : CommandHandler<PlayerCardDeleteCommand, Domain.Entities.PlayerCard>
{
    public override async Task<Domain.Entities.PlayerCard> ExecuteAsync(PlayerCardDeleteCommand command, CancellationToken ct = default)
    {
        return await _clanWarRepository.Remove(command.PlayerId, command.CardId);
    }
}