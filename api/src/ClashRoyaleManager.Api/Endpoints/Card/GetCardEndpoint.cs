using ClashRoyaleManager.Application.Query.Cards;
using FastEndpoints;
using Microsoft.EntityFrameworkCore.Query;

namespace ClashRoyaleManager.Presentation.Endpoints;

public class GetCardEndpoint : Endpoint<CardQuery, CardQueryResponse>
{
    public override void Configure()
    {
        Get("/cards/{Id}");
        AllowAnonymous();
    }

    public async override Task HandleAsync(CardQuery req, CancellationToken ct)
    {
        //req.Id = Route<Guid>("cardId"); 
        var response = await req.ExecuteAsync(ct);
        await SendAsync(response);
    }
}