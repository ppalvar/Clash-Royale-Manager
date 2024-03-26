using ClashRoyaleManager.Application.Commands.Admin.CreateChallenge;
using FastEndpoints;

namespace ClashRoyaleManager.Presentation.Endpoints;

public class CreateChallengeEndpoint : Endpoint<CreateChallengeCommand, CreateChallengeCommandResponse>
{
    private readonly ICommandHandler<CreateChallengeCommand, CreateChallengeCommandResponse> _commandHandler;

    public CreateChallengeEndpoint(ICommandHandler<CreateChallengeCommand, CreateChallengeCommandResponse> commandHandler)
    {
        _commandHandler = commandHandler;
    }

    public override void Configure()
    {
        Post("/admin/createchallenge");
        AllowAnonymous();
    }

    public override async Task HandleAsync(CreateChallengeCommand req, CancellationToken ct)
    {
        CreateChallengeCommandResponse response = await _commandHandler.ExecuteAsync(req, ct);
        await SendAsync(response);
    }
}