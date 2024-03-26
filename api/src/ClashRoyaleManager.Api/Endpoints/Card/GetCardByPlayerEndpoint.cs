using ClashRoyaleManager.Application.Query.Cards;
using FastEndpoints;
using Microsoft.EntityFrameworkCore.Query;

namespace ClashRoyaleManager.Presentation.Endpoints;

public class GetCardByPlayerEndpoint : Endpoint<CardByPlayerQuery, CardByPlayerQueryResponse>
{
    public override void Configure()
    {
        Get("/cards-by-player/{playerId}");
        AllowAnonymous();
    }

    public async override Task HandleAsync(CardByPlayerQuery req, CancellationToken ct)
    {
        var response = await req.ExecuteAsync(ct);
        await SendAsync(response);
    }
}