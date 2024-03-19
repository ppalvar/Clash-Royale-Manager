using ClashRoyaleManager.Application.Query.Battles;
using FastEndpoints;

namespace ClashRoyaleManager.Presentation.Endpoints;

public class GetByPlayerBattle : Endpoint<ListBattleByPlayerQuery, ListBattleByPlayerQueryResponse>
{
    private readonly ICommandHandler<ListBattleByPlayerQuery, ListBattleByPlayerQueryResponse> _listBattleByPlayerQueryHandler;

    public GetByPlayerBattle(ICommandHandler<ListBattleByPlayerQuery, ListBattleByPlayerQueryResponse> listBattleByPlayerQueryHandler)
    {
        _listBattleByPlayerQueryHandler = listBattleByPlayerQueryHandler;
    }
    
    public override void Configure()
    {
        Get("/battles-by-player/{playerId}");
        AllowAnonymous();
    }

    public async override Task HandleAsync(ListBattleByPlayerQuery req, CancellationToken ct)
    {
        req.Id = Route<Guid>("playerId"); 
        var response = await _listBattleByPlayerQueryHandler.ExecuteAsync(req, ct);
        await SendAsync(response);
    }
}