using ClashRoyaleManager.Application.Commands.Admin.ClanWar.Create;
using ClashRoyaleManager.Domain.Entities;
using FastEndpoints;

namespace ClashRoyaleManager.Api.Endpoints.Admin;

public class CreateClanWarEndpoint : Endpoint<ClanWarCreateCommand, Domain.Entities.ClanWar>
{
    public override void Configure()
    {
        Post("/admin/clan-war");
    }

    public override async Task<ClanWar> ExecuteAsync(ClanWarCreateCommand req, CancellationToken ct)
    {
        return await req.ExecuteAsync(ct);
    }
}