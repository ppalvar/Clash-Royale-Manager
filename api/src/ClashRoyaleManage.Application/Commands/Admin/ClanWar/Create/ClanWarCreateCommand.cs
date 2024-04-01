using FastEndpoints;

namespace ClashRoyaleManager.Application.Commands.Admin.ClanWar.Create;

public class ClanWarCreateCommand : ICommand<Domain.Entities.ClanWar>
{
    public Guid ClanId { get; set; }
    public Guid WarId { get; set; }
    public int NumberOfPrizes { get; set; }
}