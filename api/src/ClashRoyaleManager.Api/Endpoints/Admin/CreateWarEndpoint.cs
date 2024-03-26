using ClashRoyaleManager.Application.Commands.Admin.CreateWar;
using FastEndpoints;

namespace ClashRoyaleManager.Presentation.Endpoints;

public class CreateWarEndpoint : Endpoint<CreateWarCommand, CreateWarCommandResponse>
{
    public override void Configure()
    {
        Post("/admin/createwar");
        AllowAnonymous();
    }

    public override async Task HandleAsync(CreateWarCommand req, CancellationToken ct)
    {
        CreateWarCommandResponse response = await req.ExecuteAsync(ct);
        await SendAsync(response);
    }
}