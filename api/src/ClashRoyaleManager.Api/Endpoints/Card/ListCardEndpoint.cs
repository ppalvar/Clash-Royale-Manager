using ClashRoyaleManager.Application.Query.Cards;
using FastEndpoints;

namespace ClashRoyaleManager.Presentation.Endpoints;

public class ListCardEndpoint : Endpoint<ListCardQuery, ListCardQueryResponse>
{
    public override void Configure()
    {
        Get("/cards");
        AllowAnonymous();
    }

    public async override Task HandleAsync(ListCardQuery req, CancellationToken ct)
    {
        var response = await req.ExecuteAsync(ct);
        await SendAsync(response);
    }
}