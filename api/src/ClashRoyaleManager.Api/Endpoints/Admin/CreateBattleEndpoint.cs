using ClashRoyaleManager.Application.Commands.Admin.CreateBattle;
using FastEndpoints;

namespace ClashRoyaleManager.Presentation.Endpoints;

public class CreateBattleEndpoint : Endpoint<CreateBattleCommand, CreateBattleCommandResponse>
{
    public override void Configure()
    {
        Post("/admin/createbattle");
    }

    public override async Task HandleAsync(CreateBattleCommand req, CancellationToken ct)
    {
        var response = await req.ExecuteAsync(ct);
        await SendAsync(response);
    }
}