using ClashRoyaleManager.Application.Commands.Admin.UpdateChallenge;
using FastEndpoints;

namespace ClashRoyaleManager.Presentation.Endpoints;

public class UpdateChallengeEndpoint : Endpoint<UpdateChallengeCommand, UpdateChallengeCommandResponse>
{
    public override void Configure()
    {
        Post("/admin/update-challenge/{challengeId}");
    }

    public override async Task HandleAsync(UpdateChallengeCommand req, CancellationToken ct)
    {
        req.Id = Route<Guid>("challengeId");
        UpdateChallengeCommandResponse response = await req.ExecuteAsync(ct);
        await SendAsync(response);
    }
}