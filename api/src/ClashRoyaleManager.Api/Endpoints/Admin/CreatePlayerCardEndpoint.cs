using ClashRoyaleManager.Application.Commands.Admin.PlayerCard.Create;
using ClashRoyaleManager.Domain.Entities;
using FastEndpoints;

namespace ClashRoyaleManager.Api.Endpoints.Admin;

public class CreatePlayerCardEndpoint : Endpoint<PlayerCardCreateCommand, Domain.Entities.PlayerCard>
{
    public override void Configure()
    {
        Post("/admin/player-card");
    }

    public override async Task<PlayerCard> ExecuteAsync(PlayerCardCreateCommand req, CancellationToken ct)
    {
        return await req.ExecuteAsync(ct);
    }
}