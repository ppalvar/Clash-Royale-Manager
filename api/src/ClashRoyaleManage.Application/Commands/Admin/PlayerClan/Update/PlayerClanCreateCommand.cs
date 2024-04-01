using FastEndpoints;

namespace ClashRoyaleManager.Application.Commands.Admin.PlayerClan.Update;

public class PlayerClanUpdateCommand : ICommand<Domain.Entities.PlayerClan>
{
    public Guid IdPlayer { get; set; }
    public Guid IdClan { get; set; }
}