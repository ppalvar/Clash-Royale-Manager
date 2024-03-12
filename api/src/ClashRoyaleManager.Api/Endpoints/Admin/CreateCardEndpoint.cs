using ClashRoyaleManager.Application.Commands.Admin.CreateCard;
using FastEndpoints;

namespace ClashRoyaleManager.Presentation.Endpoints;

public class CreateCardEndpoint : Endpoint<CreateCardCommand, CreateCardCommandResponse>
{
    private readonly ICommandHandler<CreateCardCommand, CreateCardCommandResponse> _commandHandler;

    public CreateCardEndpoint(ICommandHandler<CreateCardCommand, CreateCardCommandResponse> commandHandler)
    {
        _commandHandler = commandHandler;
    }

    public override void Configure()
    {
        Post("/admin/createcard");
        AllowAnonymous();
    }

    public override async Task HandleAsync(CreateCardCommand req, CancellationToken ct)
    {
        CreateCardCommandResponse response = await _commandHandler.ExecuteAsync(req, ct);
        await SendAsync(response);
    }
}