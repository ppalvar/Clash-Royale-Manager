using ClashRoyaleManager.Application.Query.Players;
using FastEndpoints;
using Microsoft.EntityFrameworkCore.Query;

namespace ClashRoyaleManager.Presentation.Endpoints;

public class GetPlayerEndpoint : Endpoint<PlayerQuery, PlayerQueryResponse>
{
    private readonly ICommandHandler<PlayerQuery, PlayerQueryResponse> _PlayerQueryHandler;
    public GetPlayerEndpoint(ICommandHandler<PlayerQuery, PlayerQueryResponse> PlayerQueryHandler)
    {
        _PlayerQueryHandler = PlayerQueryHandler;

    }
    
    public override void Configure()
    {
        Get("/players/{playerId}");
        AllowAnonymous();
    }

    public async override Task HandleAsync(PlayerQuery req, CancellationToken ct)
    {
        req.Id = Route<Guid>("playerId"); 
        var response = await _PlayerQueryHandler.ExecuteAsync(req, ct);
        await SendAsync(response);
    }
}