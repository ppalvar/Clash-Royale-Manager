using ClashRoyaleManager.Application.Commands.Admin.CreateTroopCard;
using FastEndpoints;

namespace ClashRoyaleManager.Presentation.Endpoints;

public class CreateTroopCardEndpoint : Endpoint<CreateTroopCardCommand, CreateTroopCardCommandResponse>
{
    public override void Configure()
    {
        Post("/admin/createtroopcard");
        AllowAnonymous();
    }

    public override async Task HandleAsync(CreateTroopCardCommand req, CancellationToken ct)
    {
        var response = await req.ExecuteAsync(ct);
        await SendAsync(response);
    }
}