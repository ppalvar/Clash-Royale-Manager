using ClashRoyaleManager.Application.Common;
using ClashRoyaleManager.Domain.Entities;

namespace ClashRoyaleManager.Application.Commands.Admin.UpdateTroopCard;

public class UpdateTroopCardCommandResponse
{
    public Guid Id { get; set; }
    public int LifePoints { get; set; }
    public int DamageInArea { get; set; }
    public int NumberOfUnits { get; set; }
}