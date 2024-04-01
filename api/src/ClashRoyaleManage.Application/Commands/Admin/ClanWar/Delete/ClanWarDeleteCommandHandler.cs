using System.Runtime.InteropServices;
using ClashRoyaleManager.Application.Repositories;
using FastEndpoints;

namespace ClashRoyaleManager.Application.Commands.Admin.ClanWar.Delete;

public class ClanWarDeleteCommandHandler(IClanWarRepository _clanWarRepository) : CommandHandler<ClanWarDeleteCommand, Domain.Entities.ClanWar>
{
    public override async Task<Domain.Entities.ClanWar> ExecuteAsync(ClanWarDeleteCommand command, CancellationToken ct = default)
    {
        return await _clanWarRepository.Remove(command.ClanId, command.WarId); ;
    }
}