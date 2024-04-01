using ClashRoyaleManager.Application.Repositories;
using ClashRoyaleManager.Application.Services;
using ClashRoyaleManager.Domain.Entities;
using FastEndpoints;

namespace ClashRoyaleManager.Application.Commands.Admin.PlayerCard.Create;

public class PlayerCardCreateCommandHandler(IPlayerCardRepository _clanWarRepository) : CommandHandler<PlayerCardCreateCommand, Domain.Entities.PlayerCard>
{
    public override async Task<Domain.Entities.PlayerCard> ExecuteAsync(PlayerCardCreateCommand command, CancellationToken ct = default)
    {
        var playerCard = new Domain.Entities.PlayerCard
        {
            IdPlayer = command.PlayerId,
            IdCard = command.CardId,
            Level = command.Level,
            IsFavority = command.IsFavorite
        };

        await _clanWarRepository.Create(playerCard);

        return playerCard;
    }
}