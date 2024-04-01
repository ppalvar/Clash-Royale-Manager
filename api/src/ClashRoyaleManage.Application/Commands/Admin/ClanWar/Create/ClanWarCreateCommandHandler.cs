using ClashRoyaleManager.Application.Repositories;
using FastEndpoints;

namespace ClashRoyaleManager.Application.Commands.Admin.ClanWar.Create;

public class ClanWarCreateCommandHandler(IClanWarRepository _clanWarRepository) : CommandHandler<ClanWarCreateCommand, Domain.Entities.ClanWar>
{
    public override async Task<Domain.Entities.ClanWar> ExecuteAsync(ClanWarCreateCommand command, CancellationToken ct = default)
    {
        var clanWar = new Domain.Entities.ClanWar
        {
            IdClan = command.ClanId,
            IdWar = command.WarId,
            NumberOfPrizes = command.NumberOfPrizes
        };

        await _clanWarRepository.Create(clanWar);

        return clanWar;
    }
}