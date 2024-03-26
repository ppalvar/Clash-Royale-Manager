using ClashRoyaleManager.Application.Query.Battles;
using FastEndpoints;

namespace ClashRoyaleManager.Presentation.Endpoints;

public class GetByPlayerBattle : Endpoint<ListBattleByPlayerQuery, ListBattleByPlayerQueryResponse>
{
    public override void Configure()
    {
        Get("/battles-by-player/{playerId}");
        AllowAnonymous();
    }

    public async override Task HandleAsync(ListBattleByPlayerQuery req, CancellationToken ct)
    {
        var response = await req.ExecuteAsync(ct);
        await SendAsync(response);
    }
}