using ClashRoyaleManager.Application.Common;
using ClashRoyaleManager.Domain.Entities;
namespace ClashRoyaleManager.Application.Commands.Admin.CreateTroopCard;

public class CreateTroopCardCommandResponse
{
    public Guid CardId { get; set; }
    public int LifePoints { get; set; }
    public int DamageInArea { get; set; }
    public int NumberOfUnits { get; set; }
}