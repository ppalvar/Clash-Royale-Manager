using FastEndpoints;
using ClashRoyaleManager.Domain.Entities;

namespace ClashRoyaleManager.Application.Commands.Admin.UpdateStructureCard;

public class UpdateStructureCardCommand : ICommand<UpdateStructureCardCommandResponse>
{
    public Guid Id { get; set; }
    public int LifePoints { get; set; }
}