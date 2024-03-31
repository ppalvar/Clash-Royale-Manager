using ClashRoyaleManager.Application.Common;
using ClashRoyaleManager.Domain.Entities;
namespace ClashRoyaleManager.Application.Commands.Admin.CreateStructureCard;

public class CreateStructureCardCommandResponse
{
    public Guid CardId { get; set; }
    public int LifePoints { get; set; }
}