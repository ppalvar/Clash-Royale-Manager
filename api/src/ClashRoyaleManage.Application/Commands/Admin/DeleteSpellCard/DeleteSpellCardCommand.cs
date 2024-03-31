using FastEndpoints;

namespace ClashRoyaleManager.Application.Commands.Admin.DeleteSpellCard;

public class DeleteSpellCardCommand : ICommand<DeleteSpellCardCommandResponse>
{
    public Guid Id { get; set; }
}