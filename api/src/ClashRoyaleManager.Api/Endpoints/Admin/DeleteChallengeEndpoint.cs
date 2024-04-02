using ClashRoyaleManager.Application.Commands.Admin.DeleteChallenge;
using FastEndpoints;

namespace ClashRoyaleManager.Presentation.Endpoints;

public class DeleteChallengeEndpoint : Endpoint<DeleteChallengeCommand, DeleteChallengeCommandResponse>
{
    public override void Configure()
    {
        Delete("/admin/delete-challenge/{challengeId}");
    }

    public override async Task HandleAsync(DeleteChallengeCommand req, CancellationToken ct)
    {
        req.Id = Route<Guid>("challengeId");
        DeleteChallengeCommandResponse response = await req.ExecuteAsync(ct);
        await SendAsync(response);
    }
}