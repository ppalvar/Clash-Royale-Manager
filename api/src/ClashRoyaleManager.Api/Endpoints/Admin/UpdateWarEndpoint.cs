using ClashRoyaleManager.Application.Commands.Admin.UpdateWar;
using FastEndpoints;

namespace ClashRoyaleManager.Presentation.Endpoints;

public class UpdateWarEndpoint : Endpoint<UpdateWarCommand, UpdateWarCommandResponse>
{
    private readonly ICommandHandler<UpdateWarCommand, UpdateWarCommandResponse> _commandHandler;

    public UpdateWarEndpoint(ICommandHandler<UpdateWarCommand, UpdateWarCommandResponse> commandHandler)
    {
        _commandHandler = commandHandler;
    }

    public override void Configure()
    {
        Post("/admin/update-war/{warId}");
        AllowAnonymous();
    }

    public override async Task HandleAsync(UpdateWarCommand req, CancellationToken ct)
    {
        req.Id = Route<Guid>("warId");
        UpdateWarCommandResponse response = await _commandHandler.ExecuteAsync(req, ct);
        await SendAsync(response);
    }
}