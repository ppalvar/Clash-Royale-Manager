using ClashRoyaleManager.Application.Commands.Admin.CreateBattle;
using FastEndpoints;

namespace ClashRoyaleManager.Presentation.Endpoints;

public class CreateBattleEndpoint : Endpoint<CreateBattleCommand, CreateBattleCommandResponse>
{
    private readonly ICommandHandler<CreateBattleCommand, CreateBattleCommandResponse> _commandHandler;

    public CreateBattleEndpoint(ICommandHandler<CreateBattleCommand, CreateBattleCommandResponse> commandHandler)
    {
        _commandHandler = commandHandler;
    }

    public override void Configure()
    {
        Post("/admin/createbattle");
        AllowAnonymous();
    }

    public override async Task HandleAsync(CreateBattleCommand req, CancellationToken ct)
    {
        CreateBattleCommandResponse response = await _commandHandler.ExecuteAsync(req, ct);
        await SendAsync(response);
    }
}