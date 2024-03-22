using ClashRoyaleManager.Application.Query.Players;
using FastEndpoints;
using Microsoft.EntityFrameworkCore.Query;

namespace ClashRoyaleManager.Presentation.Endpoints;

public class GetPlayerEndpoint : Endpoint<PlayerQuery, PlayerQueryResponse>
{
    public override void Configure()
    {
        Get("/players/{playerId}");
        AllowAnonymous();
    }

    public async override Task HandleAsync(PlayerQuery req, CancellationToken ct)
    {
        var response = await req.ExecuteAsync(ct);
        await SendAsync(response);
    }
}