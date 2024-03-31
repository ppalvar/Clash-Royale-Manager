using ClashRoyaleManager.Application.Commands.Admin;
using ClashRoyaleManager.Application.Common;
using ClashRoyaleManager.Domain.Entities;

namespace ClashRoyaleManager.Application.Commands.Admin.UpdateTroopCard;

public class UpdateTroopCardCommandMapper : AbstractMapper<TroopCard, UpdateTroopCardCommand, UpdateTroopCardCommandResponse>
{
    public override TroopCard ToEntity(UpdateTroopCardCommand command)
    {
        return new TroopCard{
            CardId = command.Id,
            LifePoints = command.LifePoints,
            DamageInArea = command.DamageInArea,
            NumberOfUnits = command.NumberOfUnits
        };
    }
    public override UpdateTroopCardCommandResponse ToResponse(TroopCard entity)
    {
        return new UpdateTroopCardCommandResponse
        {
            Id = entity.CardId,
            LifePoints = entity.LifePoints,
            DamageInArea = entity.DamageInArea,
            NumberOfUnits = entity.NumberOfUnits
        };
    }
}
