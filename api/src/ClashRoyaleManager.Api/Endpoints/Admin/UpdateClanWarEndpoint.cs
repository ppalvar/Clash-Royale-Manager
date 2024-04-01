using ClashRoyaleManager.Application.Commands.Admin.ClanWar.Update;
using ClashRoyaleManager.Domain.Entities;
using FastEndpoints;

namespace ClashRoyaleManager.Api.Endpoints.Admin;

public class UpdateClanWarEndpoint : Endpoint<ClanWarUpdateCommand, Domain.Entities.ClanWar>
{
    public override void Configure()
    {
        Patch("/admin/clan-war");
    }

    public override async Task<ClanWar> ExecuteAsync(ClanWarUpdateCommand req, CancellationToken ct)
    {
        return await req.ExecuteAsync(ct);
    }
}