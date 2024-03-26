using ClashRoyaleManager.Application.Query.Wars;
using FastEndpoints;
using Microsoft.EntityFrameworkCore.Query;

namespace ClashRoyaleManager.Presentation.Endpoints;

public class GetWarEndpoint : Endpoint<WarQuery, WarQueryResponse>
{
    private readonly ICommandHandler<WarQuery, WarQueryResponse> _WarQueryHandler;
    public GetWarEndpoint(ICommandHandler<WarQuery, WarQueryResponse> WarQueryHandler)
    {
        _WarQueryHandler = WarQueryHandler;

    }
    
    public override void Configure()
    {
        Get("/wars/{warId}");
        AllowAnonymous();
    }

    public async override Task HandleAsync(WarQuery req, CancellationToken ct)
    {
        req.Id = Route<Guid>("warId"); 
        var response = await _WarQueryHandler.ExecuteAsync(req, ct);
        await SendAsync(response);
    }
}