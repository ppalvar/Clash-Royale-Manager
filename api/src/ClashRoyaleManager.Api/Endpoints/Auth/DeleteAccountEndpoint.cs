using ClashRoyaleManager.Application.Commands.Auth;
using FastEndpoints;

namespace ClashRoyaleManager.Presentation.Endpoints;

public class DeleteAccountEndpoint : Endpoint<DeleteAccountCommand, DeleteAccountCommandResponse>
{
    public override void Configure()
    {
        Get("/auth/delete-account/{userId}");
        AllowAnonymous();
    }

    public async override Task HandleAsync(DeleteAccountCommand req, CancellationToken ct)
    {
        var response = await req.ExecuteAsync(ct);
        await SendAsync(response);
    }
}