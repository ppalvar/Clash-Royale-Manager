using ClashRoyaleManager.Application.Commands.Admin.DeleteCard;
using FastEndpoints;

namespace ClashRoyaleManager.Presentation.Endpoints;

public class DeleteCardEndpoint : Endpoint<DeleteCardCommand, DeleteCardCommandResponse>
{
    private readonly ICommandHandler<DeleteCardCommand, DeleteCardCommandResponse> _commandHandler;

    public DeleteCardEndpoint(ICommandHandler<DeleteCardCommand, DeleteCardCommandResponse> commandHandler)
    {
        _commandHandler = commandHandler;
    }

    public override void Configure()
    {
        Delete("/admin/delete-card/{userId}");
        AllowAnonymous();
    }

    public override async Task HandleAsync(DeleteCardCommand req, CancellationToken ct)
    {
        req.Id = Route<Guid>("userId");
        DeleteCardCommandResponse response = await _commandHandler.ExecuteAsync(req, ct);
        await SendAsync(response);
    }
}