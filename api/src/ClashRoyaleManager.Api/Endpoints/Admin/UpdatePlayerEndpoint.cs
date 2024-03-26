using ClashRoyaleManager.Application.Commands.Admin.UpdatePlayer;
using FastEndpoints;

namespace ClashRoyaleManager.Presentation.Endpoints;

public class UpdatePlayerEndpoint : Endpoint<UpdatePlayerCommand, UpdatePlayerCommandResponse>
{
    public override void Configure()
    {
        Post("/admin/update-player/{userId}");
        AllowAnonymous();
    }

    public override async Task HandleAsync(UpdatePlayerCommand req, CancellationToken ct)
    {
        var response = await req.ExecuteAsync(ct);
        await SendAsync(response);
    }
}