using ClashRoyaleManager.Application.Query.Cards;
using FastEndpoints;
using Microsoft.EntityFrameworkCore.Query;

namespace ClashRoyaleManager.Presentation.Endpoints;

public class GetCardEndpoint : Endpoint<CardQuery, CardQueryResponse>
{
    private readonly ICommandHandler<CardQuery, CardQueryResponse> _CardQueryHandler;
    public GetCardEndpoint(ICommandHandler<CardQuery, CardQueryResponse> CardQueryHandler)
    {
        _CardQueryHandler = CardQueryHandler;

    }
    
    public override void Configure()
    {
        Get("/cards/{cardId}");
        AllowAnonymous();
    }

    public async override Task HandleAsync(CardQuery req, CancellationToken ct)
    {
        req.Id = Route<Guid>("cardId"); 
        var response = await _CardQueryHandler.ExecuteAsync(req, ct);
        await SendAsync(response);
    }
}