using ClashRoyaleManager.Application.Commands.Admin.PlayerChallenge.Create;
using ClashRoyaleManager.Domain.Entities;
using FastEndpoints;

namespace ClashRoyaleManager.Api.Endpoints.Admin;

public class CreatePlayerChallengeEndpoint : Endpoint<PlayerChallengeCreateCommand, Domain.Entities.PlayerChallenge>
{
    public override void Configure()
    {
        Post("/admin/player-challenge");
    }

    public override async Task<PlayerChallenge> ExecuteAsync(PlayerChallengeCreateCommand req, CancellationToken ct)
    {
        return await req.ExecuteAsync(ct);
    }
}