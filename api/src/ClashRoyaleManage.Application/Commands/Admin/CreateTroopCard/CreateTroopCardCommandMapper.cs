using ClashRoyaleManager.Application.Commands.Admin;
using ClashRoyaleManager.Application.Common;
using ClashRoyaleManager.Domain.Entities;

namespace ClashRoyaleManager.Application.Commands.Admin.CreateTroopCard;

public class CreateTroopCardCommandMapper : AbstractMapper<TroopCard, CreateTroopCardCommand, CreateTroopCardCommandResponse>
{
    public override TroopCard ToEntity(CreateTroopCardCommand command)
    {
        return new TroopCard{
            CardId = command.CardId,
            LifePoints =command.LifePoints,
            DamageInArea = command.DamageInArea,
            NumberOfUnits = command.NumberOfUnits
        };
    }
    public override CreateTroopCardCommandResponse ToResponse(TroopCard entity)
    {
        return new CreateTroopCardCommandResponse
        {
            CardId = entity.CardId,
            LifePoints = entity.LifePoints,
            DamageInArea = entity.DamageInArea,
            NumberOfUnits = entity.NumberOfUnits
        };
    }
}
