using ClashRoyaleManager.Application.Query.Cards;
using FastEndpoints;

namespace ClashRoyaleManager.Presentation.Endpoints;

public class MostPopularInClanEndpoint : Endpoint<MostPopularInClanQuery, ListCardQueryResponse>
{
    public override void Configure()
    {
        AllowAnonymous();
        Get("/cards/most-popular/{clanId}");
    }

    public override async Task<ListCardQueryResponse> ExecuteAsync(MostPopularInClanQuery req, CancellationToken ct)
    {
        return await req.ExecuteAsync(ct);
    }
}