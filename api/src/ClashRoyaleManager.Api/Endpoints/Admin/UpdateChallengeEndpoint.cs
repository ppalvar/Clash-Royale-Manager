using ClashRoyaleManager.Application.Commands.Admin.UpdateChallenge;
using FastEndpoints;

namespace ClashRoyaleManager.Presentation.Endpoints;

public class UpdateChallengeEndpoint : Endpoint<UpdateChallengeCommand, UpdateChallengeCommandResponse>
{
    private readonly ICommandHandler<UpdateChallengeCommand, UpdateChallengeCommandResponse> _commandHandler;

    public UpdateChallengeEndpoint(ICommandHandler<UpdateChallengeCommand, UpdateChallengeCommandResponse> commandHandler)
    {
        _commandHandler = commandHandler;
    }

    public override void Configure()
    {
        Post("/admin/update-challenge/{challengeId}");
        AllowAnonymous();
    }

    public override async Task HandleAsync(UpdateChallengeCommand req, CancellationToken ct)
    {
        req.Id = Route<Guid>("challengeId");
        UpdateChallengeCommandResponse response = await _commandHandler.ExecuteAsync(req, ct);
        await SendAsync(response);
    }
}