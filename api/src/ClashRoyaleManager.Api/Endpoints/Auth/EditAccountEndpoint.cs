using ClashRoyaleManager.Application.Commands.Auth;
using FastEndpoints;

namespace ClashRoyaleManager.Presentation.Endpoints;

public class EditAccountEndpoint : Endpoint<EditAccountCommand, EditAccountCommandResponse>
{
    public override void Configure()
    {
        Put("/auth/update-account/{userId}");
        AllowAnonymous();
    }

    public async override Task HandleAsync(EditAccountCommand req, CancellationToken ct)
    {
        var response = await req.ExecuteAsync(ct);
        await SendAsync(response);
    }
}