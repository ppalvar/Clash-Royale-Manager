using ClashRoyaleManager.Application.Commands.Admin.CreateWar;
using FastEndpoints;

namespace ClashRoyaleManager.Presentation.Endpoints;

public class CreateWarEndpoint : Endpoint<CreateWarCommand, CreateWarCommandResponse>
{
    private readonly ICommandHandler<CreateWarCommand, CreateWarCommandResponse> _commandHandler;

    public CreateWarEndpoint(ICommandHandler<CreateWarCommand, CreateWarCommandResponse> commandHandler)
    {
        _commandHandler = commandHandler;
    }

    public override void Configure()
    {
        Post("/admin/createwar");
        AllowAnonymous();
    }

    public override async Task HandleAsync(CreateWarCommand req, CancellationToken ct)
    {
        CreateWarCommandResponse response = await _commandHandler.ExecuteAsync(req, ct);
        await SendAsync(response);
    }
}