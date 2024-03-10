using ClashRoyaleManager.Application.Query.Wars;
using FastEndpoints;

namespace ClashRoyaleManager.Presentation.Endpoints;

public class GetAllWar : Endpoint<ListWarQuery, ListWarQueryResponse>
{
    private readonly ICommandHandler<ListWarQuery, ListWarQueryResponse> _listWarQueryHandler;

    public GetAllWar(ICommandHandler<ListWarQuery, ListWarQueryResponse> listWarQueryHandler)
    {
        _listWarQueryHandler = listWarQueryHandler;
    }
    
    public override void Configure()
    {
        Get("/wars");
        AllowAnonymous();
    }

    public async override Task HandleAsync(ListWarQuery req, CancellationToken ct)
    {
        var response = await _listWarQueryHandler.ExecuteAsync(req, ct);
        await SendAsync(response);
    }
}