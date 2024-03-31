using ClashRoyaleManager.Application.Common;
using ClashRoyaleManager.Domain.Entities;

namespace ClashRoyaleManager.Application.Commands.Admin.DeleteTroopCard;

public class DeleteTroopCardCommandResponse
{
    public int LifePoints { get; set; }
    public int DamageInArea { get; set; }

    public int NumberOfUnits { get; set; }
}