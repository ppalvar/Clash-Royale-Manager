using FastEndpoints;

namespace ClashRoyaleManager.Application.Commands.Admin.ClanWar.Update;

public class ClanWarUpdateCommand : ICommand<Domain.Entities.ClanWar>
{
    public Guid ClanId { get; set; }
    public Guid WarId { get; set; }
    public int NumberOfPrizes { get; set; }
}