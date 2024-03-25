using FastEndpoints;

namespace ClashRoyaleManager.Application.Commands.Admin.DeleteWar;

public class DeleteWarCommand : ICommand<DeleteWarCommandResponse>
{
    public Guid Id { get; set; }
}