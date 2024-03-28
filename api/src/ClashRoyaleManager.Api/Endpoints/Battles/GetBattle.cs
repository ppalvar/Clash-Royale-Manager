using ClashRoyaleManager.Application.Query.Battles;
using FastEndpoints;

namespace ClashRoyaleManager.Presentation.Endpoints;

public class GetBattle : Endpoint<BattleQuery, BattleQueryResponse>
{
    public override void Configure()
    {
        Get("/battles/{Player1Id}/{Date}");
        AllowAnonymous();
    }

    public async override Task HandleAsync(BattleQuery req, CancellationToken ct)
    {
        var response = await req.ExecuteAsync(ct);
        await SendAsync(response);
    }
}