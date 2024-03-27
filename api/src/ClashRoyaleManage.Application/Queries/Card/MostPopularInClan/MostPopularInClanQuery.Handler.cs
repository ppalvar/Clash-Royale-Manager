using ClashRoyaleManager.Application.Repositories;
using FastEndpoints;

namespace ClashRoyaleManager.Application.Query.Cards;

public class MostPopularInClanQueryHandler(ICardRepository _cardRepository) : CommandHandler<MostPopularInClanQuery, ListCardQueryResponse>
{
    public override async Task<ListCardQueryResponse> ExecuteAsync(MostPopularInClanQuery command, CancellationToken ct = default)
    {
        var resp = await _cardRepository.MostPopularInClan(command.ClanId, command.Page, command.PageSize);
        return new ListCardQueryResponse
        {
            Cards = resp.Cards,
            Page = resp.Page,
            TotalPages = resp.TotalPages
        };
    }
}