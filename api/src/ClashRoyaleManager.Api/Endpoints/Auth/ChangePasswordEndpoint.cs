using ClashRoyaleManager.Application.Commands.Auth;
using FastEndpoints;

namespace ClashRoyaleManager.Presentation.Endpoints;

public class ChangePasswordEndpoint : Endpoint<ChangePasswordCommand, ChangePasswordCommandResponse>
{
    public override void Configure()
    {
        Post("/auth/change-password/{userId}");
        AllowAnonymous();
    }

    public async override Task HandleAsync(ChangePasswordCommand req, CancellationToken ct)
    {
        var response = await req.ExecuteAsync(ct);
        await SendAsync(response);
    }
}