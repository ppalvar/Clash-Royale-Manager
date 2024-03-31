using ClashRoyaleManager.Application.Commands.Admin;
using ClashRoyaleManager.Application.Common;
using ClashRoyaleManager.Domain.Entities;

namespace ClashRoyaleManager.Application.Commands.Admin.DeleteTroopCard;

public class DeleteTroopCardCommandMapper : AbstractMapper<TroopCard, DeleteTroopCardCommand, DeleteTroopCardCommandResponse>
{
    public override DeleteTroopCardCommandResponse ToResponse(TroopCard entity)
    {
        return new DeleteTroopCardCommandResponse
        {
            LifePoints = entity.LifePoints,
            DamageInArea = entity.DamageInArea,
            NumberOfUnits = entity.NumberOfUnits
        };
    }
}
