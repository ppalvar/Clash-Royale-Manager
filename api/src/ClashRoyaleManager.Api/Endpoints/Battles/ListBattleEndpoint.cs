using ClashRoyaleManager.Application.Query.Battles;
using FastEndpoints;

namespace ClashRoyaleManager.Presentation.Endpoints;

public class GetAllBattle : Endpoint<ListBattleQuery, ListBattleQueryResponse>
{
    private readonly ICommandHandler<ListBattleQuery, ListBattleQueryResponse> _listBattleQueryHandler;

    public GetAllBattle(ICommandHandler<ListBattleQuery, ListBattleQueryResponse> listBattleQueryHandler)
    {
        _listBattleQueryHandler = listBattleQueryHandler;
    }
    
    public override void Configure()
    {
        Get("/battles");
        AllowAnonymous();
    }

    public async override Task HandleAsync(ListBattleQuery req, CancellationToken ct)
    {
        var response = await _listBattleQueryHandler.ExecuteAsync(req, ct);
        await SendAsync(response);
    }
}