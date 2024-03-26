using ClashRoyaleManager.Application.Query.Clans;
using FastEndpoints;

namespace ClashRoyaleManager.Presentation.Endpoints;

public class GetAllEndpoint : Endpoint<ListClanQuery, ListClanQueryResponse>
{
    public override void Configure()
    {
        Get("/clans");
        AllowAnonymous();
    }

    public async override Task HandleAsync(ListClanQuery req, CancellationToken ct)
    {
        var response = await req.ExecuteAsync(ct);
        await SendAsync(response);
    }
}