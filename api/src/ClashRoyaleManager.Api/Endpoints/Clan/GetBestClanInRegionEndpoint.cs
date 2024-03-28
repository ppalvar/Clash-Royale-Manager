using ClashRoyaleManager.Application.Query.Clans;
using FastEndpoints;
using Microsoft.EntityFrameworkCore.Query;

namespace ClashRoyaleManager.Presentation.Endpoints;

public class GetBestClanInRegionEndpoint : Endpoint<ClanRegionQuery, ClanRegionQueryResponse>
{
    public override void Configure()
    {
        Get("/clanregion/{region}");
        AllowAnonymous();
    }

    public async override Task HandleAsync(ClanRegionQuery req, CancellationToken ct)
    {
        req.Region = Route<int>("region"); 
        var response = await req.ExecuteAsync(ct);
        await SendAsync(response);
    }
}