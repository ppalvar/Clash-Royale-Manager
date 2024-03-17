using ClashRoyaleManager.Application.Query.Players;
using FastEndpoints;

namespace ClashRoyaleManager.Presentation.Endpoints;

public class ListPlayerEndpoint : Endpoint<ListPlayerQuery, ListPlayerQueryResponse>
{
    private readonly ICommandHandler<ListPlayerQuery, ListPlayerQueryResponse> _listPlayerQueryHandler;

    public ListPlayerEndpoint(ICommandHandler<ListPlayerQuery, ListPlayerQueryResponse> listPlayerQueryHandler)
    {
        _listPlayerQueryHandler = listPlayerQueryHandler;
    }
    
    public override void Configure()
    {
        Get("/players");
        AllowAnonymous();
    }

    public async override Task HandleAsync(ListPlayerQuery req, CancellationToken ct)
    {
        var response = await _listPlayerQueryHandler.ExecuteAsync(req, ct);
        await SendAsync(response);
    }
}