using ClashRoyaleManager.Application.Commands.Admin.PlayerClan.Create;
using ClashRoyaleManager.Domain.Entities;
using FastEndpoints;

namespace ClashRoyaleManager.Api.Endpoints.Admin;

public class CreatePlayerClanEndpoint : Endpoint<PlayerClansCreateCommand, Domain.Entities.PlayerClan>
{
    public override void Configure()
    {
        Post("/admin/player-clan");
    }

    public override async Task<PlayerClan> ExecuteAsync(PlayerClansCreateCommand req, CancellationToken ct)
    {
        return await req.ExecuteAsync(ct);
    }
}