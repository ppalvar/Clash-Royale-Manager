using ClashRoyaleManager.Application.Commands.Admin.ClanWar.Delete;
using ClashRoyaleManager.Domain.Entities;
using FastEndpoints;

namespace ClashRoyaleManager.Api.Endpoints.Admin;

public class DeleteClanWarEndpoint : Endpoint<ClanWarDeleteCommand, Domain.Entities.ClanWar>
{
    public override void Configure()
    {
        Delete("/admin/clan-war");
    }

    public override async Task<ClanWar> ExecuteAsync(ClanWarDeleteCommand req, CancellationToken ct)
    {
        return await req.ExecuteAsync(ct);
    }
}