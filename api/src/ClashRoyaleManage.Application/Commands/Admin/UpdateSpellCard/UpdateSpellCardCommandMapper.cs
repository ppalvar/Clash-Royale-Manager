using ClashRoyaleManager.Application.Commands.Admin;
using ClashRoyaleManager.Application.Common;
using ClashRoyaleManager.Domain.Entities;

namespace ClashRoyaleManager.Application.Commands.Admin.UpdateSpellCard;

public class UpdateSpellCardCommandMapper : AbstractMapper<SpellCard, UpdateSpellCardCommand, UpdateSpellCardCommandResponse>
{
    public override SpellCard ToEntity(UpdateSpellCardCommand command)
    {
        return new SpellCard{
            CardId = command.Id,
            Radio = command.Radio,
            Duration = command.Duration,
            DamageToTowers = command.DamageToTowers,
            DamageInArea = command.DamageInArea
        };
    }
    public override UpdateSpellCardCommandResponse ToResponse(SpellCard entity)
    {
        return new UpdateSpellCardCommandResponse
        {
            Id = entity.CardId,
            Radio = entity.Radio,
            Duration = entity.Duration,
            DamageToTowers = entity.DamageToTowers,
            DamageInArea = entity.DamageInArea
        };
    }
}
