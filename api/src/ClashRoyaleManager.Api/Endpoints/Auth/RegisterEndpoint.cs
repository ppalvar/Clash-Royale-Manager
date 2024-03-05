using ClashRoyaleManager.Application.Commands.Auth;
using FastEndpoints;

namespace ClashRoyaleManager.Presentation.Endpoints;

public class RegisterEndpoint : Endpoint<RegisterCommand, RegisterCommandResponse>
{
    private readonly ICommandHandler<RegisterCommand, RegisterCommandResponse> _commandHandler;

    public RegisterEndpoint(ICommandHandler<RegisterCommand, RegisterCommandResponse> commandHandler)
    {
        _commandHandler = commandHandler;
    }

    public override void Configure()
    {
        Post("/auth/register");
        AllowAnonymous();
    }

    public override async Task HandleAsync(RegisterCommand req, CancellationToken ct)
    {
        RegisterCommandResponse response = await _commandHandler.ExecuteAsync(req, ct);
        await SendAsync(response);
    }
}