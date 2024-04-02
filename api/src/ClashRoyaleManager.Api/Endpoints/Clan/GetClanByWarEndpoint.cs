using ClashRoyaleManager.Application.Queries.ClanWar.GetByWar;
using FastEndpoints;
using Microsoft.EntityFrameworkCore.Query;

namespace ClashRoyaleManager.Presentation.Endpoints;

public class GetClanByWarsEndpoint : Endpoint<GetAllClanByWarsQuery, GetAllClanByWarsQueryResponse>
{
    public override void Configure()
    {
        Get("/clans/clans-by-war/{Id}");
        AllowAnonymous();
    }

    public async override Task HandleAsync(GetAllClanByWarsQuery req, CancellationToken ct)
    {
        var response = await req.ExecuteAsync(ct);
        await SendAsync(response);
    }
}