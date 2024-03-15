using ClashRoyaleManager.Application.Commands.Admin.DeletePlayer;
using FastEndpoints;

namespace ClashRoyaleManager.Presentation.Endpoints;

public class DeletePlayerEndpoint : Endpoint<DeletePlayerCommand, DeletePlayerCommandResponse>
{
    private readonly ICommandHandler<DeletePlayerCommand, DeletePlayerCommandResponse> _commandHandler;

    public DeletePlayerEndpoint(ICommandHandler<DeletePlayerCommand, DeletePlayerCommandResponse> commandHandler)
    {
        _commandHandler = commandHandler;
    }

    public override void Configure()
    {
        Delete("/admin/delete-player/{userId}");
        AllowAnonymous();
    }

    public override async Task HandleAsync(DeletePlayerCommand req, CancellationToken ct)
    {
        req.Id = Route<Guid>("userId");
        DeletePlayerCommandResponse response = await _commandHandler.ExecuteAsync(req, ct);
        await SendAsync(response);
    }
}