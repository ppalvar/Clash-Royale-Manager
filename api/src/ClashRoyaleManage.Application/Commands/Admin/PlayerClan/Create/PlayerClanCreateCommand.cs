using FastEndpoints;

namespace ClashRoyaleManager.Application.Commands.Admin.PlayerClan.Create;

public class PlayerClansCreateCommand : ICommand<Domain.Entities.PlayerClan>
{
    public Guid IdPlayer { get; set; }
    public Guid IdClan { get; set; }
}