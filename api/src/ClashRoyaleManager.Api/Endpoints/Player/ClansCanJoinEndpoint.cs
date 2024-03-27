using ClashRoyaleManager.Application.Query.Players;
using FastEndpoints;

namespace ClashRoyaleManager.Presentation.Endpoints;

public class ClansCanJoinEndpoint : Endpoint<ClansCanJoinQuery, ClansCanJoinResponse>
{
    public override void Configure()
    {
        AllowAnonymous();
        Get("/players/clans-can-join/{playerId}");
    }

    public override async Task<ClansCanJoinResponse> ExecuteAsync(ClansCanJoinQuery req, CancellationToken ct)
    {
        return await req.ExecuteAsync(ct);
    }
}