using ClashRoyaleManager.Application.Commands.Auth;
using FastEndpoints;

namespace ClashRoyaleManager.Presentation.Endpoints;

public class RegisterEndpoint : Endpoint<RegisterCommand>
{
    public override void Configure()
    {
        Post("/api/auth/register");
        AllowAnonymous();
    }

    public override async Task HandleAsync(RegisterCommand req, CancellationToken ct)
    {
        await req.ExecuteAsync(ct);
        await SendOkAsync();
    }
}