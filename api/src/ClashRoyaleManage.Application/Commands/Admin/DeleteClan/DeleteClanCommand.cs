using FastEndpoints;

namespace ClashRoyaleManager.Application.Commands.Admin.DeleteClan;

public class DeleteClanCommand : ICommand<DeleteClanCommandResponse>
{
    public Guid Id { get; set; }
}