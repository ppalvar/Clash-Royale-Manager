using FastEndpoints;

namespace ClashRoyaleManager.Application.Commands.Admin.DeletePlayer;

public class DeletePlayerCommand : ICommand<DeletePlayerCommandResponse>
{
    public Guid Id { get; set; }
}