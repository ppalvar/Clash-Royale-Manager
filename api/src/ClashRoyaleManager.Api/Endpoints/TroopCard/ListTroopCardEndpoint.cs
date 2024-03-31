using ClashRoyaleManager.Application.Query.TroopCards;
using FastEndpoints;

namespace ClashRoyaleManager.Presentation.Endpoints;

public class GetAllTroopCardEndpoint : Endpoint<ListTroopCardQuery, ListTroopCardQueryResponse>
{
    public override void Configure()
    {
        Get("/troopcards");
        AllowAnonymous();
    }

    public async override Task HandleAsync(ListTroopCardQuery req, CancellationToken ct)
    {
        var response = await req.ExecuteAsync(ct);
        await SendAsync(response);
    }
}