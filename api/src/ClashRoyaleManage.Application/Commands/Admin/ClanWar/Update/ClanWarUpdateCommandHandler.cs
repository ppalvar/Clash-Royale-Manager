using ClashRoyaleManager.Application.Repositories;
using FastEndpoints;

namespace ClashRoyaleManager.Application.Commands.Admin.ClanWar.Update;

public class ClanWarUpdateCommandHandler(IClanWarRepository _clanWarRepository) : CommandHandler<ClanWarUpdateCommand, Domain.Entities.ClanWar>
{
    public override async Task<Domain.Entities.ClanWar> ExecuteAsync(ClanWarUpdateCommand command, CancellationToken ct = default)
    {
        var clanWar = new Domain.Entities.ClanWar
        {
            IdClan = command.ClanId,
            IdWar = command.WarId,
            NumberOfPrizes = command.NumberOfPrizes
        };

        await _clanWarRepository.Update(clanWar);

        return clanWar;
    }
}