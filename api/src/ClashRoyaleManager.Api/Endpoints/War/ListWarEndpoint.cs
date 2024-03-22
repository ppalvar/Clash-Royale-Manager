using ClashRoyaleManager.Application.Query.Wars;
using FastEndpoints;

namespace ClashRoyaleManager.Presentation.Endpoints;

public class GetAllWar : Endpoint<ListWarQuery, ListWarQueryResponse>
{
    public override void Configure()
    {
        Get("/wars");
        AllowAnonymous();
    }

    public async override Task HandleAsync(ListWarQuery req, CancellationToken ct)
    {
        var response = await req.ExecuteAsync(ct);
        await SendAsync(response);
    }
}