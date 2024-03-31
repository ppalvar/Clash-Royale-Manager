using ClashRoyaleManager.Application.Query.StructureCards;
using FastEndpoints;

namespace ClashRoyaleManager.Presentation.Endpoints;

public class GetAllStructureCardEndpoint : Endpoint<ListStructureCardQuery, ListStructureCardQueryResponse>
{
    public override void Configure()
    {
        Get("/structurecards");
        AllowAnonymous();
    }

    public async override Task HandleAsync(ListStructureCardQuery req, CancellationToken ct)
    {
        var response = await req.ExecuteAsync(ct);
        await SendAsync(response);
    }
}