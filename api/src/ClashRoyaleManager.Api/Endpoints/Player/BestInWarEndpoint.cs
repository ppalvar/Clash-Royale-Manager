using ClashRoyaleManager.Application.Query.Players;
using FastEndpoints;

namespace ClashRoyaleManager.Presentation.Endpoints;

public class BestInWarEndpoint : Endpoint<ListBestPlayersInWarQuery, ListPlayerQueryResponse>
{
    public override void Configure()
    {
        AllowAnonymous();
        Get("/players/best-in-war/{warId}");
    }

    public override async Task<ListPlayerQueryResponse> ExecuteAsync(ListBestPlayersInWarQuery req, CancellationToken ct)
    {
        return await req.ExecuteAsync(ct);
    }
}