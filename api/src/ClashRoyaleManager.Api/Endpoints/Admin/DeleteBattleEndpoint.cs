using ClashRoyaleManager.Application.Commands.Admin.DeleteBattle;
using FastEndpoints;

namespace ClashRoyaleManager.Presentation.Endpoints;

public class DeleteBattleEndpoint : Endpoint<DeleteBattleCommand, DeleteBattleCommandResponse>
{
    public override void Configure()
    {
        Delete("/admin/delete-battle/{Id}/{Date}");
    }

    public override async Task HandleAsync(DeleteBattleCommand req, CancellationToken ct)
    {
        DeleteBattleCommandResponse response = await req.ExecuteAsync(ct);
        await SendAsync(response);
    }
}