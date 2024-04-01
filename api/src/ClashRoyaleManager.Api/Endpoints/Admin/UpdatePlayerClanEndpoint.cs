using ClashRoyaleManager.Application.Commands.Admin.PlayerClan.Update;
using ClashRoyaleManager.Domain.Entities;
using FastEndpoints;

namespace ClashRoyaleManager.Api.Endpoints.Admin;

public class UpdatePlayerClanEndpoint : Endpoint<PlayerClanUpdateCommand, Domain.Entities.PlayerClan>
{
    public override void Configure()
    {
        Patch("/admin/player-clan");
    }

    public override async Task<PlayerClan> ExecuteAsync(PlayerClanUpdateCommand req, CancellationToken ct)
    {
        return await req.ExecuteAsync(ct);
    }
}