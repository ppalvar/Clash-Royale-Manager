using ClashRoyaleManager.Application.Queries.ClanWar.GetAll;
using FastEndpoints;

namespace ClashRoyaleManager.Api.Endpoints.Admin;

public class ListClanWarEndpoint : Endpoint<GetAllClanWarsQuery, GetAllClanWarsQueryResponse>
{
    public override void Configure()
    {
        AllowAnonymous();
        Get("/clan-war");
    }

    public override async Task<GetAllClanWarsQueryResponse> ExecuteAsync(GetAllClanWarsQuery req, CancellationToken ct)
    {
        return await req.ExecuteAsync(ct);
    }
}