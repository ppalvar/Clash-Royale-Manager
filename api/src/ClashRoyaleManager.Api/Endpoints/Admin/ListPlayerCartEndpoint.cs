using ClashRoyaleManager.Application.Queries.PlayerCard.GetAll;
using FastEndpoints;

namespace ClashRoyaleManager.Api.Endpoints.Admin;

public class ListPlayerCardEndpoint : Endpoint<PlayerCardGetAllQuery, PlayerCardGetAllQueryResponse>
{
    public override void Configure()
    {
        AllowAnonymous();
        Get("/player-card");
    }

    public override async Task<PlayerCardGetAllQueryResponse> ExecuteAsync(PlayerCardGetAllQuery req, CancellationToken ct)
    {
        return await req.ExecuteAsync(ct);
    }
}