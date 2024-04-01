using ClashRoyaleManager.Application.Queries.PlayerClan.GetAll;
using FastEndpoints;

namespace ClashRoyaleManager.Api.Endpoints.Admin;

public class ListPlayerClanEndpoint : Endpoint<GetAllPlayerClanQuery, GetAllPlayerClanQueryResponse>
{
    public override void Configure()
    {
        AllowAnonymous();
        Get("/player-clan");
    }

    public override async Task<GetAllPlayerClanQueryResponse> ExecuteAsync(GetAllPlayerClanQuery req, CancellationToken ct)
    {
        return await req.ExecuteAsync(ct);
    }
}