using ClashRoyaleManager.Application.Commands.Admin.DeleteWar;
using FastEndpoints;

namespace ClashRoyaleManager.Presentation.Endpoints;

public class DeleteWarEndpoint : Endpoint<DeleteWarCommand, DeleteWarCommandResponse>
{
    private readonly ICommandHandler<DeleteWarCommand, DeleteWarCommandResponse> _commandHandler;

    public DeleteWarEndpoint(ICommandHandler<DeleteWarCommand, DeleteWarCommandResponse> commandHandler)
    {
        _commandHandler = commandHandler;
    }

    public override void Configure()
    {
        Delete("/admin/delete-war/{warId}");
        AllowAnonymous();
    }

    public override async Task HandleAsync(DeleteWarCommand req, CancellationToken ct)
    {
        req.Id = Route<Guid>("warId");
        DeleteWarCommandResponse response = await _commandHandler.ExecuteAsync(req, ct);
        await SendAsync(response);
    }
}