using ClashRoyaleManager.Application.Commands.Admin.UpdatePlayer;
using FastEndpoints;

namespace ClashRoyaleManager.Presentation.Endpoints;

public class UpdatePlayerEndpoint : Endpoint<UpdatePlayerCommand, UpdatePlayerCommandResponse>
{
    private readonly ICommandHandler<UpdatePlayerCommand, UpdatePlayerCommandResponse> _commandHandler;

    public UpdatePlayerEndpoint(ICommandHandler<UpdatePlayerCommand, UpdatePlayerCommandResponse> commandHandler)
    {
        _commandHandler = commandHandler;
    }

    public override void Configure()
    {
        Post("/admin/update-player/{userId}");
        AllowAnonymous();
    }

    public override async Task HandleAsync(UpdatePlayerCommand req, CancellationToken ct)
    {
        req.Id = Route<Guid>("userId");
        UpdatePlayerCommandResponse response = await _commandHandler.ExecuteAsync(req, ct);
        await SendAsync(response);
    }
}