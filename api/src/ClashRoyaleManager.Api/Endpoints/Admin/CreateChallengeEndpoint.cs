using ClashRoyaleManager.Application.Commands.Admin.CreateChallenge;
using FastEndpoints;

namespace ClashRoyaleManager.Presentation.Endpoints;

public class CreateChallengeEndpoint : Endpoint<CreateChallengeCommand, CreateChallengeCommandResponse>
{
    public override void Configure()
    {
        Post("/admin/createchallenge");
    }

    public override async Task HandleAsync(CreateChallengeCommand req, CancellationToken ct)
    {
        CreateChallengeCommandResponse response = await req.ExecuteAsync(ct);
        await SendAsync(response);
    }
}