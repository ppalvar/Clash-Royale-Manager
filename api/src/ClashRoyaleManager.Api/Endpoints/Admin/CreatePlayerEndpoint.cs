using ClashRoyaleManager.Application.Commands.Admin.CreatePlayer;
using FastEndpoints;

namespace ClashRoyaleManager.Presentation.Endpoints;

public class CreatePlayerEndpoint : Endpoint<CreatePlayerCommand, CreatePlayerCommandResponse>
{
    public override void Configure()
    {
        Post("/admin/createplayer");
        AllowAnonymous();
    }

    public override async Task HandleAsync(CreatePlayerCommand req, CancellationToken ct)
    {
        var response = await req.ExecuteAsync(ct);
        await SendAsync(response);
    }
}