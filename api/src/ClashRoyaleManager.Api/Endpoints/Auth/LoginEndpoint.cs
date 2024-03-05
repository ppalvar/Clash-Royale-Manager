using ClashRoyaleManager.Application.Query.Auth;
using FastEndpoints;

namespace ClashRoyaleManager.Presentation.Endpoints;

public class LoginEndpoint : Endpoint<LoginCommand, LoginCommandResponse>
{
    private readonly ICommandHandler<LoginCommand, LoginCommandResponse> _queryHandler;

    public LoginEndpoint(ICommandHandler<LoginCommand, LoginCommandResponse> commandHandler)
    {
        _queryHandler = commandHandler;
    }

    public override void Configure()
    {
        Post("/auth/Login");
        AllowAnonymous();
    }

    public override async Task HandleAsync(LoginCommand req, CancellationToken ct)
    {
        LoginCommandResponse response = await _queryHandler.ExecuteAsync(req, ct);
        await SendAsync(response);
    }
}