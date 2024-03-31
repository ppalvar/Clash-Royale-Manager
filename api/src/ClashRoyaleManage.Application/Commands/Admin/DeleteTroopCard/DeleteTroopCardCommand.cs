using FastEndpoints;

namespace ClashRoyaleManager.Application.Commands.Admin.DeleteTroopCard;

public class DeleteTroopCardCommand : ICommand<DeleteTroopCardCommandResponse>
{
    public Guid Id { get; set; }
}