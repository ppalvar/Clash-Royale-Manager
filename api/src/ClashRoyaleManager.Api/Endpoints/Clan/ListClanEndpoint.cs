using ClashRoyaleManager.Application.Query.Clans;
using FastEndpoints;

namespace ClashRoyaleManager.Presentation.Endpoints;

public class GetAllEndpoint : Endpoint<ListClanQuery, ListClanQueryResponse>
{
    private readonly ICommandHandler<ListClanQuery, ListClanQueryResponse> _listClanQueryHandler;

    public GetAllEndpoint(ICommandHandler<ListClanQuery, ListClanQueryResponse> listClanQueryHandler)
    {
        _listClanQueryHandler = listClanQueryHandler;
    }
    
    public override void Configure()
    {
        Get("/clans");
        AllowAnonymous();
    }

    public async override Task HandleAsync(ListClanQuery req, CancellationToken ct)
    {
        var response = await _listClanQueryHandler.ExecuteAsync(req, ct);
        await SendAsync(response);
    }
}