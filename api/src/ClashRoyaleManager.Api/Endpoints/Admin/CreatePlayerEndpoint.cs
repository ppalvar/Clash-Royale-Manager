using ClashRoyaleManager.Application.Commands.Admin.CreatePlayer;
using FastEndpoints;

namespace ClashRoyaleManager.Presentation.Endpoints;

public class CreatePlayerEndpoint : Endpoint<CreatePlayerCommand, CreatePlayerCommandResponse>
{
    private readonly ICommandHandler<CreatePlayerCommand, CreatePlayerCommandResponse> _commandHandler;

    public CreatePlayerEndpoint(ICommandHandler<CreatePlayerCommand, CreatePlayerCommandResponse> commandHandler)
    {
        _commandHandler = commandHandler;
    }

    public override void Configure()
    {
        Post("/admin/createplayer");
        AllowAnonymous();
    }

    public override async Task HandleAsync(CreatePlayerCommand req, CancellationToken ct)
    {
        CreatePlayerCommandResponse response = await _commandHandler.ExecuteAsync(req, ct);
        await SendAsync(response);
    }
}