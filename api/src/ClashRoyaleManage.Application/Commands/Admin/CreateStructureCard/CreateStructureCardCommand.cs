using FastEndpoints;

namespace ClashRoyaleManager.Application.Commands.Admin.CreateStructureCard;

public class CreateStructureCardCommand : ICommand<CreateStructureCardCommandResponse>
{
    public Guid CardId { get; set; }
    public int LifePoints { get; set; }

}