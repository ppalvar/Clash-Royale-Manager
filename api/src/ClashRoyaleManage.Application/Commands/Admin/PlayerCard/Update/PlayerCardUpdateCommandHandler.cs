using ClashRoyaleManager.Application.Repositories;
using ClashRoyaleManager.Application.Services;
using ClashRoyaleManager.Domain.Entities;
using FastEndpoints;

namespace ClashRoyaleManager.Application.Commands.Admin.PlayerCard.Update;

public class PlayerCardUpdateCommandHandler(IPlayerCardRepository _clanWarRepository, IDateTimeProvider _dateTimeProvider) : CommandHandler<PlayerCardUpdateCommand, Domain.Entities.PlayerCard>
{
    public override async Task<Domain.Entities.PlayerCard> ExecuteAsync(PlayerCardUpdateCommand command, CancellationToken ct = default)
    {
        var playerCard = new Domain.Entities.PlayerCard
        {
            IdPlayer = command.PlayerId,
            IdCard = command.CardId,
            Level = command.Level,
            IsFavority = command.IsFavorite,
            Fecha = _dateTimeProvider.UtcNow
        };

        await _clanWarRepository.Update(playerCard);

        return playerCard;
    }
}