using ClashRoyaleManager.Application.Query.StructureCards;
using FastEndpoints;
using Microsoft.EntityFrameworkCore.Query;

namespace ClashRoyaleManager.Presentation.Endpoints;

public class GetStructureCardEndpoint : Endpoint<StructureCardQuery, StructureCardQueryResponse>
{
    public override void Configure()
    {
        Get("/structurecards/{Id}");
        AllowAnonymous();
    }

    public async override Task HandleAsync(StructureCardQuery req, CancellationToken ct)
    {
        var response = await req.ExecuteAsync(ct);
        await SendAsync(response);
    }
}