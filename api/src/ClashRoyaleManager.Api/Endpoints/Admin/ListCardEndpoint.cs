using ClashRoyaleManager.Application.Query.Cards;
using FastEndpoints;

namespace ClashRoyaleManager.Presentation.Endpoints;

public class ListCardEndpoint : Endpoint<ListCardQuery, ListCardQueryResponse>
{
    private readonly ICommandHandler<ListCardQuery, ListCardQueryResponse> _listCardQueryHandler;

    public ListCardEndpoint(ICommandHandler<ListCardQuery, ListCardQueryResponse> listCardQueryHandler)
    {
        _listCardQueryHandler = listCardQueryHandler;
    }
    
    public override void Configure()
    {
        Get("/cards");
        AllowAnonymous();
    }

    public async override Task HandleAsync(ListCardQuery req, CancellationToken ct)
    {
        var response = await _listCardQueryHandler.ExecuteAsync(req, ct);
        await SendAsync(response);
    }
}