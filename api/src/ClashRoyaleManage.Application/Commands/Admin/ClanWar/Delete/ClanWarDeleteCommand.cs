using FastEndpoints;

namespace ClashRoyaleManager.Application.Commands.Admin.ClanWar.Delete;

public class ClanWarDeleteCommand : ICommand<Domain.Entities.ClanWar>
{
    public Guid ClanId { get; set; }
    public Guid WarId { get; set; }
}