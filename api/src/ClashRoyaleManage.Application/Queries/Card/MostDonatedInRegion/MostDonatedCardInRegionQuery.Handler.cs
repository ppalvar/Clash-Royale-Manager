using ClashRoyaleManager.Application.Repositories;
using ClashRoyaleManager.Domain.Entities;
using FastEndpoints;

namespace ClashRoyaleManager.Application.Query.Cards;

public class MostDonatedCardInRegionQueryHandler(ICardRepository _cardRepository) : CommandHandler<MostDonatedCardInRegionQuery, Card?>
{
    public override async Task<Card?> ExecuteAsync(MostDonatedCardInRegionQuery command, CancellationToken ct = default)
    {
        var response = await _cardRepository.MostDonatedInRegion(command.Region);

        return response;
    }
}