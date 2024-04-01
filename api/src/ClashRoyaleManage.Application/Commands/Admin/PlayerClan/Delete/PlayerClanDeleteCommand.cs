using FastEndpoints;

namespace ClashRoyaleManager.Application.Commands.Admin.PlayerClan.Delete;

public class PlayerClanDeleteCommand : ICommand<Domain.Entities.PlayerClan>
{
    public Guid IdPlayer { get; set; }
    public Guid IdClan { get; set; }
}