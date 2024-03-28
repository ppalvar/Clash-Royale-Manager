using ClashRoyaleManager.Application.Query.Clans;
using FastEndpoints;
using Microsoft.EntityFrameworkCore.Query;

namespace ClashRoyaleManager.Presentation.Endpoints;

public class GetClanEndpoint : Endpoint<ClanQuery, ClanQueryResponse>
{
    public override void Configure()
    {
        Get("/clans/{Id}");
        AllowAnonymous();
    }

    public async override Task HandleAsync(ClanQuery req, CancellationToken ct)
    {
        //req.Id = Route<Guid>("clanId"); 
        var response = await req.ExecuteAsync(ct);
        await SendAsync(response);
    }
}