using FastEndpoints;

namespace ClashRoyaleManager.Application.Commands.Admin.DeleteCard;

public class DeleteCardCommand : ICommand<DeleteCardCommandResponse>
{
    public Guid Id { get; set; }
}