using ClashRoyaleManager.Application.Query.Players;
using FastEndpoints;

namespace ClashRoyaleManager.Presentation.Endpoints;

public class ListPlayerEndpoint : Endpoint<ListPlayerQuery, ListPlayerQueryResponse>
{
    public override void Configure()
    {
        Get("/players");
        AllowAnonymous();
    }

    public async override Task HandleAsync(ListPlayerQuery req, CancellationToken ct)
    {
        var response = await req.ExecuteAsync(ct);
        await SendAsync(response);
    }
}