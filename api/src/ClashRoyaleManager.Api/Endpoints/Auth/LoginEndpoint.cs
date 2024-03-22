using ClashRoyaleManager.Application.Query.Auth;
using FastEndpoints;

namespace ClashRoyaleManager.Presentation.Endpoints;

public class LoginEndpoint : Endpoint<LoginCommand, LoginCommandResponse>
{
    public override void Configure()
    {
        Post("/auth/Login");
        AllowAnonymous();
    }

    public override async Task HandleAsync(LoginCommand req, CancellationToken ct)
    {
        LoginCommandResponse response = await req.ExecuteAsync(ct);
        await SendAsync(response);
    }
}