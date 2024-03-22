using ClashRoyaleManager.Application.Query.Battles;
using FastEndpoints;

namespace ClashRoyaleManager.Presentation.Endpoints;

public class GetAllBattle : Endpoint<ListBattleQuery, ListBattleQueryResponse>
{
    public override void Configure()
    {
        Get("/battles");
        AllowAnonymous();
    }

    public async override Task HandleAsync(ListBattleQuery req, CancellationToken ct)
    {
        var response = await req.ExecuteAsync(ct);
        await SendAsync(response);
    }
}