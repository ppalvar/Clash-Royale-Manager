using ClashRoyaleManager.Application.Commands.Admin.UpdateCard;
using FastEndpoints;

namespace ClashRoyaleManager.Presentation.Endpoints;

public class UpdateCardEndpoint : Endpoint<UpdateCardCommand, UpdateCardCommandResponse>
{
    private readonly ICommandHandler<UpdateCardCommand, UpdateCardCommandResponse> _commandHandler;

    public UpdateCardEndpoint(ICommandHandler<UpdateCardCommand, UpdateCardCommandResponse> commandHandler)
    {
        _commandHandler = commandHandler;
    }

    public override void Configure()
    {
        Post("/admin/update-card/{userId}");
        AllowAnonymous();
    }

    public override async Task HandleAsync(UpdateCardCommand req, CancellationToken ct)
    {
        req.Id = Route<Guid>("userId");
        UpdateCardCommandResponse response = await _commandHandler.ExecuteAsync(req, ct);
        await SendAsync(response);
    }
}