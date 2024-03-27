using ClashRoyaleManager.Application.Query.Cards;
using ClashRoyaleManager.Domain.Entities;
using FastEndpoints;

namespace ClashRoyaleManager.Presentation.Endpoints;

public class MostDonatedInRegionEndpoint : Endpoint<MostDonatedCardInRegionQuery, Card?>
{
    public override void Configure()
    {
        AllowAnonymous();
        Get("/cards/most-donated/{region}");
    }

    public override async Task<Card?> ExecuteAsync(MostDonatedCardInRegionQuery req, CancellationToken ct)
    {
        return await req.ExecuteAsync(ct);
    }
}