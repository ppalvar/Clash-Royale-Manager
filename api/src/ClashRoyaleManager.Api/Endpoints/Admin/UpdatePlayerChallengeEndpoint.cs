using ClashRoyaleManager.Application.Commands.Admin.PlayerChallenge.Update;
using ClashRoyaleManager.Domain.Entities;
using FastEndpoints;

namespace ClashRoyaleManager.Api.Endpoints.Admin;

public class UpdatePlayerChallengeEndpoint : Endpoint<PlayerChallengeUpdateCommand, Domain.Entities.PlayerChallenge>
{
    public override void Configure()
    {
        Patch("/admin/player-challenge");
    }

    public override async Task<PlayerChallenge> ExecuteAsync(PlayerChallengeUpdateCommand req, CancellationToken ct)
    {
        return await req.ExecuteAsync(ct);
    }
}