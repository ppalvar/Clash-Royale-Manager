using ClashRoyaleManager.Application.Commands.Admin.PlayerClan.Delete;
using ClashRoyaleManager.Domain.Entities;
using FastEndpoints;

namespace ClashRoyaleManager.Api.Endpoints.Admin;

public class DeletePlayerClanEndpoint : Endpoint<PlayerClanDeleteCommand, Domain.Entities.PlayerClan>
{
    public override void Configure()
    {
        Delete("/admin/player-clan");
    }

    public override async Task<PlayerClan> ExecuteAsync(PlayerClanDeleteCommand req, CancellationToken ct)
    {
        return await req.ExecuteAsync(ct);
    }
}