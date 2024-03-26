using ClashRoyaleManager.Application.Commands.Admin.DeleteChallenge;
using FastEndpoints;

namespace ClashRoyaleManager.Presentation.Endpoints;

public class DeleteChallengeEndpoint : Endpoint<DeleteChallengeCommand, DeleteChallengeCommandResponse>
{
    private readonly ICommandHandler<DeleteChallengeCommand, DeleteChallengeCommandResponse> _commandHandler;

    public DeleteChallengeEndpoint(ICommandHandler<DeleteChallengeCommand, DeleteChallengeCommandResponse> commandHandler)
    {
        _commandHandler = commandHandler;
    }

    public override void Configure()
    {
        Delete("/admin/delete-challenge/{challengeId}");
        AllowAnonymous();
    }

    public override async Task HandleAsync(DeleteChallengeCommand req, CancellationToken ct)
    {
        req.Id = Route<Guid>("challengeId");
        DeleteChallengeCommandResponse response = await _commandHandler.ExecuteAsync(req, ct);
        await SendAsync(response);
    }
}