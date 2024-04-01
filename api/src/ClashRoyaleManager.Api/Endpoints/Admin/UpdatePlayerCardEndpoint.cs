using ClashRoyaleManager.Application.Commands.Admin.PlayerCard.Update;
using ClashRoyaleManager.Domain.Entities;
using FastEndpoints;

namespace ClashRoyaleManager.Api.Endpoints.Admin;

public class UpdatePlayerCardEndpoint : Endpoint<PlayerCardUpdateCommand, Domain.Entities.PlayerCard>
{
    public override void Configure()
    {
        Patch("/admin/player-card");
    }

    public override async Task<PlayerCard> ExecuteAsync(PlayerCardUpdateCommand req, CancellationToken ct)
    {
        return await req.ExecuteAsync(ct);
    }
}