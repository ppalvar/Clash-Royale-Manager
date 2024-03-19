using ClashRoyaleManager.Application.Query.Cards;
using FastEndpoints;
using Microsoft.EntityFrameworkCore.Query;

namespace ClashRoyaleManager.Presentation.Endpoints;

public class GetCardByPlayerEndpoint : Endpoint<CardByPlayerQuery, CardByPlayerQueryResponse>
{
    private readonly ICommandHandler<CardByPlayerQuery, CardByPlayerQueryResponse> _CardByPlayerQueryHandler;
    public GetCardByPlayerEndpoint(ICommandHandler<CardByPlayerQuery, CardByPlayerQueryResponse> CardByPlayerQueryHandler)
    {
        _CardByPlayerQueryHandler = CardByPlayerQueryHandler;
    }
    
    public override void Configure()
    {
        Get("/cards-by-player/{playerId}");
        AllowAnonymous();
    }

    public async override Task HandleAsync(CardByPlayerQuery req, CancellationToken ct)
    {
        req.Id = Route<Guid>("playerId"); 
        var response = await _CardByPlayerQueryHandler.ExecuteAsync(req, ct);
        await SendAsync(response);
    }
}