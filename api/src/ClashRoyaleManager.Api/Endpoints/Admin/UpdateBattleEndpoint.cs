using ClashRoyaleManager.Application.Commands.Admin.UpdateBattle;
using FastEndpoints;

namespace ClashRoyaleManager.Presentation.Endpoints;

public class UpdateBattleEndpoint : Endpoint<UpdateBattleCommand, UpdateBattleCommandResponse>
{
    public override void Configure()
    {
        Post("/admin/update-battle/{Player1Id}/{Date}");
        AllowAnonymous();
    }

    public override async Task HandleAsync(UpdateBattleCommand req, CancellationToken ct)
    {
        var response = await req.ExecuteAsync(ct);
        await SendAsync(response);
    }
}