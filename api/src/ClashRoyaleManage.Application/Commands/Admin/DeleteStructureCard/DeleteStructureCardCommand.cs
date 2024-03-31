using FastEndpoints;

namespace ClashRoyaleManager.Application.Commands.Admin.DeleteStructureCard;

public class DeleteStructureCardCommand : ICommand<DeleteStructureCardCommandResponse>
{
    public Guid Id { get; set; }
}