using ClashRoyaleManager.Application.Commands.Admin.PlayerCard.Delete;
using ClashRoyaleManager.Domain.Entities;
using FastEndpoints;

namespace ClashRoyaleManager.Api.Endpoints.Admin;

public class DeletePlayerCardEndpoint : Endpoint<PlayerCardDeleteCommand, Domain.Entities.PlayerCard>
{
    public override void Configure()
    {
        Delete("/admin/player-card");
    }

    public override async Task<PlayerCard> ExecuteAsync(PlayerCardDeleteCommand req, CancellationToken ct)
    {
        return await req.ExecuteAsync(ct);
    }
}