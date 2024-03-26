using ClashRoyaleManager.Application.Query.Wars;
using FastEndpoints;
using Microsoft.EntityFrameworkCore.Query;

namespace ClashRoyaleManager.Presentation.Endpoints;

public class GetWarEndpoint : Endpoint<WarQuery, WarQueryResponse>
{
    
    public override void Configure()
    {
        Get("/wars/{warId}");
        AllowAnonymous();
    }

    public async override Task HandleAsync(WarQuery req, CancellationToken ct)
    {
        req.Id = Route<Guid>("warId"); 
        var response = await req.ExecuteAsync(ct);
        await SendAsync(response);
    }
}