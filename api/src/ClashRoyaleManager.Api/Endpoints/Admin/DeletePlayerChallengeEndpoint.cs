using ClashRoyaleManager.Application.Commands.Admin.PlayerChallenge.Delete;
using ClashRoyaleManager.Domain.Entities;
using FastEndpoints;

namespace ClashRoyaleManager.Api.Endpoints.Admin;

public class DeletePlayerChallengeEndpoint : Endpoint<PlayerChallengeDeleteCommand, Domain.Entities.PlayerChallenge>
{
    public override void Configure()
    {
        Delete("/admin/player-challenge");
    }

    public override async Task<PlayerChallenge> ExecuteAsync(PlayerChallengeDeleteCommand req, CancellationToken ct)
    {
        return await req.ExecuteAsync(ct);
    }
}