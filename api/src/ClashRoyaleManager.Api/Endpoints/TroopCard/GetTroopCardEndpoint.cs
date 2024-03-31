using ClashRoyaleManager.Application.Query.TroopCards;
using FastEndpoints;
using Microsoft.EntityFrameworkCore.Query;

namespace ClashRoyaleManager.Presentation.Endpoints;

public class GetTroopCardEndpoint : Endpoint<TroopCardQuery, TroopCardQueryResponse>
{
    public override void Configure()
    {
        Get("/troopcards/{Id}");
        AllowAnonymous();
    }

    public async override Task HandleAsync(TroopCardQuery req, CancellationToken ct)
    {
        var response = await req.ExecuteAsync(ct);
        await SendAsync(response);
    }
}