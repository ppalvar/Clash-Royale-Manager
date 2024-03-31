using ClashRoyaleManager.Application.Common;
using ClashRoyaleManager.Domain.Entities;

namespace ClashRoyaleManager.Application.Commands.Admin.UpdateStructureCard;

public class UpdateStructureCardCommandResponse
{
    public Guid Id { get; set; }
    public int LifePoints { get; set; }
}